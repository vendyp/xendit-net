using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Xendit.Net
{
    public class DefaultHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;
        private static readonly Lazy<HttpClient> LazuDefaultHttpClient = new Lazy<HttpClient>(BuildHttpClient);

        /// <summary>
        /// Default timespan before the request times out.
        /// </summary>
        /// <returns></returns>
        public static TimeSpan DefaultHttpTimeout => TimeSpan.FromSeconds(90);

        public DefaultHttpClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? LazuDefaultHttpClient.Value;
        }

        public async Task<XenditResponse> SendAsync(XenditRequest request, CancellationToken cancellationToken)
        {
            Exception reqException = null;
            HttpResponseMessage response = null;

            var httpRequest = BuildRequestMessage(request.Uri, request.Method, request.Headers, request.Content);

            try
            {
                response = await _httpClient.SendAsync(httpRequest, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                reqException = exception;
            }
            catch (Exception ex)
            {
                reqException = ex;
            }

            if (reqException != null)
            {
                throw reqException;
            }

            var reader = new StreamReader(await response.Content.ReadAsStreamAsync()
                .ConfigureAwait(false));

            return new XenditResponse(
                response.StatusCode,
                await reader.ReadToEndAsync().ConfigureAwait(false),
                response.Headers);
        }

        public HttpRequestMessage BuildRequestMessage(Uri uri, HttpMethod method, Dictionary<string, string> headers, HttpContent content = null)
        {
            var req = new HttpRequestMessage();

            req.RequestUri = uri;

            req.Method = method;

            if (headers != null && headers.Any())
            {
                foreach (var item in headers)
                {
                    if (item.Key.ToUpper() == "AUTHORIZATION")
                    {
                        req.Headers.Authorization = new AuthenticationHeaderValue("Basic", item.Value);
                    }
                    else
                    {
                        req.Headers.TryAddWithoutValidation(name: item.Key, value: item.Value);
                    }
                }
            }

            if (content != null)
            {
                req.Content = content;
            }

            return req;
        }

        public static HttpClient BuildHttpClient()
        {
            return new HttpClient
            {
                Timeout = DefaultHttpTimeout,
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xendit.Net
{
    public class XenditClient : IXenditClient
    {
        private string _baseUrl = "https://api.xendit.co/";
        private readonly XenditOptions _options;
        private readonly IHttpClient _httpClient;

        public XenditClient(XenditOptions options) : this(options, null)
        {
        }

        public XenditClient(XenditOptions options, IHttpClient httpClient)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _httpClient = httpClient ?? new DefaultHttpClient();

            if (string.IsNullOrWhiteSpace(_options.ApiKey))
            {
                throw new ArgumentException($"{nameof(XenditOptions.ApiKey)} can not be null or empty", nameof(XenditOptions.ApiKey));
            }
        }

        public async Task<T> MakeRequestAsync<T>(
            string path,
            HttpMethod method,
            BaseRequestOptions baseOptions,
            CancellationToken cancellationToken) where T : class
        {
            Uri uri = BuildUri(path, method, baseOptions);

            XenditRequest request = BuildRequest(uri, method, baseOptions);

            var resp = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            return JsonUtil.DeserializeObject<T>(resp.Content);
        }

        private XenditRequest BuildRequest(Uri uri, HttpMethod method, BaseRequestOptions baseOptions)
        {
            HttpContent content = null;

            if (method != HttpMethod.Get && baseOptions != null)
            {
                content = new StringContent(JsonUtil.SerializeObject(baseOptions), Encoding.UTF8, "application/json");
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Authorization", StringUtil.GenerateBasicAuthentication(_options.ApiKey, null));

            if (baseOptions != null)
            {
                if (baseOptions.Headers.Any())
                {
                    if (baseOptions.Headers.Any(x => x.Key.ToUpper() == "AUTHORIZATION"))
                    {
                        throw new Exception("Base options headers can not added key Authorization");
                    }

                    foreach (var item in baseOptions.Headers)
                    {
                        dict.Add(item.Key, item.Value);
                    }
                }
            }

            return new XenditRequest(uri, method, content, dict);
        }

        private Uri BuildUri(string path, HttpMethod method, BaseRequestOptions baseOptions)
        {
            var sb = new StringBuilder();

            sb.Append(baseOptions?.BaseUrl ?? _baseUrl);
            sb.Append(path);

            if (method == HttpMethod.Get && baseOptions != null)
            {
                string queryString = CreateQueryString(baseOptions);
                if (!string.IsNullOrWhiteSpace(queryString))
                {
                    sb.Append("?");
                    sb.Append(queryString);
                }
            }

            return new Uri(sb.ToString());
        }

        private string CreateQueryString(BaseRequestOptions baseOptions)
        {
            if (baseOptions.Queries.Any())
            {
                return string.Join(
                    "&",
                    baseOptions.Queries.Select(kvp => $"{UrlEncode(kvp.Key)}={UrlEncode(kvp.Value)}"));
            }

            return string.Empty;
        }

        private static string UrlEncode(string value)
        {
            return WebUtility.UrlEncode(value);
        }
    }
}

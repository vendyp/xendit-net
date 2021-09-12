using System;
using System.Net;
using System.Net.Http.Headers;

namespace Xendit.Net
{
    public class XenditResponse
    {
        public XenditResponse(HttpStatusCode httpStatusCode, string content, HttpHeaders headers)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException($"'{nameof(content)}' cannot be null or empty.", nameof(content));
            }

            HttpStatusCode = httpStatusCode;
            Headers = headers;
            Content = content;
        }

        public HttpStatusCode HttpStatusCode { get; }
        public HttpHeaders Headers { get; }
        public string Content { get; }
    }
}

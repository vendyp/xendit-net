using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Xendit.Net
{
    public class XenditRequest
    {
        public XenditRequest(Uri uri, HttpMethod method, HttpContent content, Dictionary<string, string> headers)
        {
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
            Method = method ?? throw new ArgumentNullException(nameof(method));
            Content = content;
            Headers = headers;
        }

        public Uri Uri { get; }
        public HttpMethod Method { get; }
        public HttpContent Content { get; }
        public Dictionary<string, string> Headers { get; }
    }
}

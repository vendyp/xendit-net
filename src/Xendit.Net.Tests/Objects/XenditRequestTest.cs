using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Xendit.Net.Tests.Objects
{
    public class XenditRequestTest
    {
        private const string _url = "https://www.google.com/";

        [Fact]
        public void XenditRequest_Ctor_Must_Correct()
        {
            // Given 
            var uri = new Uri(_url);
            var method = HttpMethod.Get;
            HttpContent content = null;
            Dictionary<string, string> headers = null;

            var ctr = new XenditRequest(uri, method, content, headers);

            Assert.Equal(uri, ctr.Uri);
            Assert.Equal(method, ctr.Method);
            Assert.Equal(content, ctr.Content);
            Assert.Equal(headers, ctr.Headers);
        }

        [Fact]
        public void XenditRequest_Ctor_Must_Throw_ArgsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new XenditRequest(null, HttpMethod.Get, null, null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new XenditRequest(new Uri(_url), null, null, null);
            });
        }
    }
}

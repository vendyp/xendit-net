using System;
using System.Net;
using System.Net.Http.Headers;
using Xunit;

namespace Xendit.Net.Tests.Objects
{
    public class XenditResponseTest
    {
        [Fact]
        public void XenditResponse_Ctor_Must_Correct()
        {
            //Given
            HttpStatusCode httpStatusCode = HttpStatusCode.OK;
            HttpHeaders headers = null;
            string content = "\"Test\"";

            //When
            var ctr = new XenditResponse(httpStatusCode, content, headers);

            //Then
            Assert.Equal(httpStatusCode, ctr.HttpStatusCode);
            Assert.Equal(headers, ctr.Headers);
            Assert.Equal(content, ctr.Content);
        }

        [Fact]
        public void XenditResponse_Ctor_Must_Throws_ArgsNull()
        {
            //Given
            HttpStatusCode httpStatusCode = HttpStatusCode.OK;
            HttpHeaders headers = null;
            string content = null;

            //When
            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new XenditResponse(httpStatusCode, content, headers);
            });
        }
    }
}

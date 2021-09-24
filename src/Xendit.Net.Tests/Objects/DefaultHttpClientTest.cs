using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Xendit.Net.Tests.Objects
{
    public class DefaultHttpClientTest
    {
        [Fact]
        public async Task DefaultHttpClient_Must_Return_Correct_Result_Async()
        {
            //Given
            var uri = new Uri("https://api.xendit.co/balance");
            var headers = new Dictionary<string, string>();
            string username = "xnd_development_O46JfOtygef9kMNsK+ZPGT+ZZ9b3ooF4w3Dn+R1k+2fT/7GlCAN3jg==";
            headers.Add("Authorization", StringUtil.GenerateBasicAuthentication(username, null));

            var request = new XenditRequest(uri, HttpMethod.Get, null, headers);

            //When
            var httpClient = new DefaultHttpClient();
            var result = await httpClient.SendAsync(request, CancellationToken.None);

            Assert.Equal(HttpStatusCode.OK, result.HttpStatusCode);
        }
    }
}

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Xendit.Net.Tests.Objects
{
    public class XenditClientTests
    {
        public XenditOptions GetXenditOptions()
        {
            return new XenditOptions
            {
                ApiKey = "xnd_development_P4qDfOss0OCpl8RtKrROHjaQYNCk9dN5lSfk+R1l9Wbe+rSiCwZ3jw=="
            };
        }

        [Fact]
        public void XenditClient_Ctor_Ok()
        {
            _ = new XenditClient(GetXenditOptions());
        }

        [Fact]
        public void XenditClient_Ctor_Should_Throw_ArgNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new XenditClient(null);
            });
        }

        [Fact]
        public void XenditClient_Ctor_Should_Throw_ArgException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new XenditClient(new XenditOptions
                {
                    ApiKey = null
                });
            });
        }

        [Fact]
        public async Task XenditClient_MakeRequestAsync_Should_OkAsync()
        {
            var client = new XenditClient(GetXenditOptions());

            var resp = await client.MakeRequestAsync<BalanceModel>("balance", System.Net.Http.HttpMethod.Get, null, System.Threading.CancellationToken.None).ConfigureAwait(false);

            Assert.NotNull(resp);
        }
    }

    public class BalanceModel
    {
        [JsonProperty("balace")]
        public int Balance { get; set; }
    }
}

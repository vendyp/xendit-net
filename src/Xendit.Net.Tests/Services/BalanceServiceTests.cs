using System;
using System.Threading.Tasks;
using Xunit;

namespace Xendit.Net.Tests.Services
{
    public class BalanceServiceTests
    {
        [Fact]
        public void BalanceService_Ctor_Throw_ArgNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var service = new BalanceService(null);
            });
        }

        [Theory]
        [InlineData(BalanceType.CASH)]
        [InlineData(BalanceType.HOLDING)]
        [InlineData(BalanceType.TAX)]
        public async Task BalanceService_GetAsync_Not_NullAsync(BalanceType type)
        {
            var balance = new BalanceService(XenditNetTestFixtures.GetXenditClient());

            Assert.NotNull(await balance.GetAsync(type).ConfigureAwait(false));
        }
    }
}

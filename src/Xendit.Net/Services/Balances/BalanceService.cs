using System.Threading;
using System.Threading.Tasks;

namespace Xendit.Net
{
    public class BalanceService : Service
    {
        private readonly IXenditClient _client;

        public BalanceService(IXenditClient client)
        {
            _client = client ?? throw new System.ArgumentNullException(nameof(client));
        }

        public override string BasePath => "balance";

        public virtual Task<BalanceOptions> GetAsync(BalanceType balanceType = BalanceType.CASH, CancellationToken cancellationToken = default)
        {
            var baseRequestOptions = GetBaseRequestOptions();

            switch (balanceType)
            {
                case BalanceType.CASH:
                    baseRequestOptions.AddHeaderParams("account_type", nameof(BalanceType.CASH));
                    break;
                case BalanceType.HOLDING:
                    baseRequestOptions.AddHeaderParams("account_type", nameof(BalanceType.HOLDING));
                    break;
                case BalanceType.TAX:
                    baseRequestOptions.AddHeaderParams("account_type", nameof(BalanceType.TAX));
                    break;
            }

            return _client.MakeRequestAsync<BalanceOptions>(BasePath, System.Net.Http.HttpMethod.Get, baseRequestOptions, cancellationToken);
        }
    }
}

using System;
using Xendit.Net;

namespace SimpleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new XenditOptions()
            {
                //REPLACE THIS KEY WITH YOURS
                ApiKey = "xnd_development_O46JfOtygef9kMNsK+ZPGT+ZZ9b3ooF4w3Dn+R1k+2fT/7GlCAN3jg=="
            };

            var client = new XenditClient(cfg);

            var balance = new BalanceService(client);

            var balanceResult = balance.GetAsync().GetAwaiter().GetResult();

            Console.WriteLine($"Your current balance : {balanceResult.Balance}");
            Console.ReadKey();
        }
    }
}

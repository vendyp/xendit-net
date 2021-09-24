using Newtonsoft.Json;

namespace Xendit.Net
{
    public class BalanceOptions
    {
        [JsonProperty("balance")]
        public int Balance { get; set; }
    }
}

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Xendit.Net
{
    public class BaseRequestOptions
    {
        [JsonIgnore]
        public string IdempotencyKey { get; set; }
        [JsonIgnore]
        public string BaseUrl => "https://api.xendit.co/";
        [JsonIgnore]
        public List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
        [JsonIgnore]
        public List<KeyValuePair<string, string>> Headers = new List<KeyValuePair<string, string>>();

        public void AddQueryParams(string key, string value)
        {
            Queries.Add(new KeyValuePair<string, string>(key, value));
        }

        public void AddHeaderParams(string key, string value)
        {
            if (Headers.Any(x => x.Key == key))
            {
                var header = Headers.First(x => x.Key == key);
                Headers.Remove(header);
            }

            Headers.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}

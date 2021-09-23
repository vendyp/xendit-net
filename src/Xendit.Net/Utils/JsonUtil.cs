using System;
using Newtonsoft.Json;

namespace Xendit.Net
{
    public static class JsonUtil
    {
        public static string SerializeObject(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return JsonConvert.SerializeObject(obj, Formatting.None);
        }

        public static T DeserializeObject<T>(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException($"'{nameof(s)}' cannot be null or whitespace.", nameof(s));
            }

            return JsonConvert.DeserializeObject<T>(s);
        }
    }
}

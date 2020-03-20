using Newtonsoft.Json;

namespace Milk.Weather.Domain
{
    public static class JsonHelper
    {
        public static string SerializeString(object obj)
        {
            return JsonConvert.SerializeObject(obj);

        }

        public static T DeserializeObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
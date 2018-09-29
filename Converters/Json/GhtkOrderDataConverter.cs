using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YiyilookGhtk.Classes.ResponseWrappers;

namespace YiyilookGhtk.Converters.Json
{
    internal class GhtkOrderDataConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var userToken = token?.SelectToken("order");
            var order = userToken != null
                ? userToken.ToObject<GhtkOrder>()
                : token?.ToObject<GhtkOrder>();
            return order;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GhtkOrder);
        }
    }
}

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
    class FeeInfoDataConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var feeToken = token?.SelectToken("fee");
            var fee = feeToken != null
                ? feeToken.ToObject<FeeInfo>()
                : token?.ToObject<FeeInfo>();
            return fee;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(FeeInfo);
        }
    }
}

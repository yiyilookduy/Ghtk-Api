using Newtonsoft.Json;

namespace YiyilookGhtk.Classes.ResponseWrappers
{
    public class GhtkOrder
    {

        [JsonProperty("label_id")]
        public string LabelId { get; set; }

        [JsonProperty("partner_id")]
        public string PartnerId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("insurance")]
        public string Insurance { get; set; }

        [JsonProperty("ship_money")]
        public string ShipMoney { get; set; }

        [JsonProperty("storage_day")]
        public string StorageDay { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("pick_money")]
        public string PickMoney { get; set; }

        [JsonProperty("is_freeship")]
        public string IsFreeship { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("customer_fullname")]
        public string CustomerFullname { get; set; }

        [JsonProperty("customer_tel")]
        public string CustomerTel { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("pick_date")]
        public string PickDate { get; set; }

        [JsonProperty("deliver_date")]
        public string DeliverDate { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("status_text")]
        public string StatusText { get; set; }
    }
}

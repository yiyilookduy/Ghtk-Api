using Newtonsoft.Json;

namespace YiyilookGhtk.Classes.ResponseWrappers
{
    public class FeeInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fee")]
        public int Fee { get; set; }

        [JsonProperty("insurance_fee")]
        public int InsuranceFee { get; set; }

        [JsonProperty("delivery_type")]
        public string DeliveryType { get; set; }

        [JsonProperty("a")]
        public string A { get; set; }

        [JsonProperty("dt")]
        public string Dt { get; set; }

        [JsonProperty("delivery")]  
        public bool Delivery { get; set; }

        [JsonProperty("cost_id")]
        public string CostId { get; set; }

        [JsonProperty("include_vat")]
        public string IncludeVat { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

//
using Newtonsoft.Json;
using YiyilookGhtk.Classes;
using YiyilookGhtk.Classes.DTOS;
using YiyilookGhtk.Classes.ResponseWrappers;
using YiyilookGhtk.Converters.Json;
using YiyilookGhtk.Helper;
using GhtkOrder = YiyilookGhtk.Classes.ResponseWrappers.GhtkOrder;

namespace YiyilookGhtk.API
{
    public class GhtkApi : IGhtkApi
    {
        private readonly HttpRequestProcessor _httpRequestProcessor;

        public GhtkApi() => _httpRequestProcessor = new HttpRequestProcessor(new HttpClient());

        public async Task<IResult<GhtkOrder>> GetStatusOrderAsync(string idOrder)
        {
            try
            {
                var statusOrderUri = new Uri($"https://services.giaohangtietkiem.vn/services/shipment/v2/{idOrder}");

                var request = HttpHelper.GetDefaultRequest(HttpMethod.Get, statusOrderUri);

                var response = await _httpRequestProcessor.SendAsync(request);

                var json = await response.Content.ReadAsStringAsync();

                var messageResponse = JsonConvert.DeserializeObject<dynamic>(json);

                if (messageResponse["success"] == false)
                {
                    return Result.Fail<GhtkOrder>(messageResponse["message"].ToString());
                }

                var order = JsonConvert.DeserializeObject<GhtkOrder>(json, new GhtkOrderDataConverter());

                return Result.Success(order);
            }
            catch (Exception e)
            {
                return Result.Fail<GhtkOrder>(e.Message);
            }
        }

        public async Task<IResult<FeeInfo>> GetFeeInfo(FeeRequestObject feeObject)
        {
            var feeInfoUri = "https://services.giaohangtietkiem.vn/services/shipment/fee?";
            string[] s = new string[6];

            s[0] = "address="+feeObject.Address;
            s[1] = "district="+feeObject.District;
            s[2] = "pick_district="+feeObject.PickDistrict;
            s[3] = "pick_province="+feeObject.PickProvince;
            s[4] = "province="+feeObject.Province;
            s[5] = "value="+feeObject.Value.ToString();
            s[6] = "weight="+feeObject.Weight.ToString();

            string a = string.Join("&", s);

            feeInfoUri += a;

            var request = HttpHelper.GetDefaultRequest(HttpMethod.Get, new Uri(feeInfoUri));

            var response = await _httpRequestProcessor.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();

            var messageResponse = JsonConvert.DeserializeObject<dynamic>(json);

            if (messageResponse["success"] == false)
            {
                return Result.Fail<FeeInfo>(messageResponse["message"].ToString());
            }

            var feeInfo = JsonConvert.DeserializeObject<FeeInfo>(json, new FeeInfoDataConverter());

            return Result.Success(feeInfo);
        }
    }
}

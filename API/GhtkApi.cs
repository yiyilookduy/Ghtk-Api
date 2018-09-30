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

namespace YiyilookGhtk.API
{
    public class GhtkApi : IGhtkApi
    {
        private readonly IHttpRequestProcessor _httpRequestProcessor;

        public GhtkApi()
        {
            var httpClientHandler = new HttpClientHandler();
            var httpClient = new HttpClient(httpClientHandler);
            _httpRequestProcessor = new HttpRequestProcessor(httpClient,httpClientHandler);
        }

        public async Task<IResult<GhtkOrder>> GetStatusOrderAsync(string idOrder)
        {
            try
            {
                var statusOrderUri = UriHelper.GetStatusOrderUri(idOrder);

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
            try
            {
                var feeInfoUri = UriHelper.GetFeeInfoUri(feeObject);

                var request = HttpHelper.GetDefaultRequest(HttpMethod.Get, feeInfoUri);

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
            catch (Exception e)
            {
                return Result.Fail<FeeInfo>(e.Message);
            }
        }

        public async Task<IResult<string>> GetFeeOfOrder(FeeRequestObject feeObject)
        {
            try
            {
                var feeObjectResult = await GetFeeInfo(feeObject);
                if (!feeObjectResult.Succeeded)
                    return Result.Fail<string>("Error");
                return Result.Success(feeObjectResult.Value.Fee.ToString());
            }
            catch (Exception e)
            {
                return Result.Fail<string>(e.Message);
            }
        }
    }
}

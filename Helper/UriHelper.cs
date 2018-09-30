using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiyilookGhtk.API;
using YiyilookGhtk.Classes.DTOS;

namespace YiyilookGhtk.Helper
{
    public static class UriHelper
    {
        private static readonly Uri BaseGhtkUri = new Uri(GhtkApiConstants.GHTK_URL);

        public static Uri GetStatusOrderUri(string idOrder)
        {
            if (!Uri.TryCreate(BaseGhtkUri, string.Format(GhtkApiConstants.STATUS_ORDER, idOrder),
                out var statusOrderUri))
                throw new Exception("Cant create Uri to get status of order");
            return statusOrderUri;
        }

        public static Uri GetFeeInfoUri(FeeRequestObject feeObject)
        {
            string[] payload = new string[7];

            payload[0] = "address=" + feeObject.Address;
            payload[1] = "district=" + feeObject.District;
            payload[2] = "pick_district=" + feeObject.PickDistrict;
            payload[3] = "pick_province=" + feeObject.PickProvince;
            payload[4] = "province=" + feeObject.Province;
            payload[5] = "value=" + feeObject.Value;
            payload[6] = "weight=" + feeObject.Weight;

            if (!Uri.TryCreate(BaseGhtkUri, "shipment/fee?"+string.Join("&", payload), out var feeInfoUri))
                throw new Exception("Cant create Uri to get fee of order");
            return feeInfoUri;
        }
    }
}

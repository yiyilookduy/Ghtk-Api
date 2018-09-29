using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpRequestMessage = System.Net.Http.HttpRequestMessage;

namespace YiyilookGhtk.Helper
{
    internal static class HttpHelper
    {
        public static HttpRequestMessage GetDefaultRequest(HttpMethod method, Uri uri)
        {
            var request = new HttpRequestMessage(method,uri);
            request.Headers.Add("Token", "Token API");
            return request;
        }
    }
}

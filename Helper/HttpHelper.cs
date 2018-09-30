using System;
using System.Net.Http;
using YiyilookGhtk.API;

namespace YiyilookGhtk.Helper
{
    internal static class HttpHelper
    {
        public static HttpRequestMessage GetDefaultRequest(HttpMethod method, Uri uri)
        {
            var request = new HttpRequestMessage(method,uri);
            request.Headers.Add("Token", GhtkApiConstants.TOKEN);
            return request;
        }
    }
}

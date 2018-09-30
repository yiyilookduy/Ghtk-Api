using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YiyilookGhtk.Classes
{
    public class HttpRequestProcessor : IHttpRequestProcessor
    {

        public HttpClient Client { get; }

        public HttpClientHandler HttpHandler { get; }

        public HttpRequestProcessor(HttpClient client, HttpClientHandler httpHandler)
        {
            Client = client;
            HttpHandler = httpHandler;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            return await SendAsync(requestMessage, CancellationToken.None);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            var response = await Client.SendAsync(requestMessage, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            
            var response = await Client.GetAsync(requestUri);
            return response;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage,
            HttpCompletionOption completionOption)
        {
            
            var response = await Client.SendAsync(requestMessage, completionOption);
            return response;
        }
    }
}

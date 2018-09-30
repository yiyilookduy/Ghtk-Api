using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YiyilookGhtk.Classes
{
    public interface IHttpRequestProcessor
    {
        HttpClient Client { get; }

        HttpClientHandler HttpHandler { get; }

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken);

        Task<HttpResponseMessage> GetAsync(Uri requestUri);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage,
            HttpCompletionOption completionOption);

    }
}

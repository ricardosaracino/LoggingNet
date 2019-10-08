using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LoggingNet.Handlers
{
    public class LoggingHandler: DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("TestHandler Before Request");

            var response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine("TestHandler After Request");

            return response;
        }
    }
}
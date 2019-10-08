using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using LoggingNet.Models;
using Serilog;

namespace LoggingNet.Handlers
{
    /// <summary>
    /// https://gist.github.com/mrshridhara/0f6a4ed1277dbc467f75
    /// </summary>
    public class LoggingHandler : DelegatingHandler
    {
        private readonly ILogger _logger;

        public LoggingHandler(ILogger logger)
        {
            _logger = logger;
        }

         protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var startTime = DateTime.Now;

            // MUST CALL AWAIT FOR SESSION
            var responseMessage = await base.SendAsync(request, cancellationToken);
            
            var endTime = DateTime.Now;
            
            var currentUser = (CurrentUser)HttpContext.Current?.Session?["currentUser"];

            _logger.Information("{0} {1} {2} {3}", request.Method, request.RequestUri.AbsolutePath,
                (endTime - startTime).TotalSeconds, currentUser?.Id);
            
            return responseMessage;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LoggingNet.Handlers;
using Serilog;

namespace LoggingNet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var log = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .CreateLogger();
            
                log.Information("Hello, Serilog!");
                log.Warning("Goodbye, Serilog.");
            


            // Web API configuration and services
            config.MessageHandlers.Add(new LoggingHandler(log));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
               // constraints: null,
                //handler: new LoggingHandler()
            );
        }
    }
}
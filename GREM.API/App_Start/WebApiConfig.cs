using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using GREM.DAL;
using GREM.DAL.Interfaces;
using CustomerService.Utils.Helpers;
using GREM.API.Container;
using GREM.API.Filters;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using System.Net.Http.Extensions.Compression.Core.Compressors;


using System.Net.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;



namespace GREM.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            IUnityContainer container = new UnityContainer();
            RegisterDependency.Register(ref container);

            config.DependencyResolver = new UnityResolver(container);
            config.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));

            config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));

            config.MapHttpAttributeRoutes();
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            // Web API routes
            //config.EnableCors();
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new UnhandledExceptionFilter());

  


      
        }
    
    }
}

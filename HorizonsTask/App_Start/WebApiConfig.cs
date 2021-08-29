using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;

namespace HorizonsTask
{
    public static class WebApiConfig
    {
        
        

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //1-Remove XML Format
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //2-Set JsonIgnore By Default for All Entities that contain that issue
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

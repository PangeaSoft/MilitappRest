using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;

namespace MilitappRest.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Configuración para que el json que retorna valores nulos, no aparezca en la respuesta.
            //Tambien se agrego la cultura porque no se reconocia desde global.asax
            config.Formatters.JsonFormatter.SerializerSettings = 
                new Newtonsoft.Json.JsonSerializerSettings() { 
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Unspecified,
                    Culture = CultureInfo.GetCultureInfo("es-AR")
                };
        }
    }
}

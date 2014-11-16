using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sat.Web.App_Start
{
    public class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api


            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var serializerSettings = new JsonSerializerSettings();
            //Mostrar la fecha en formato ISO.
            serializerSettings.Converters.Add(new IsoDateTimeConverter());
            //Formato de fecha
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            var jsonFormatter = new JsonMediaTypeFormatter { SerializerSettings = serializerSettings };
            GlobalConfiguration.Configuration.Formatters.Add(jsonFormatter);
        }
    }
}
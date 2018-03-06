using ExampleApp.Infraestructure;
using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ExampleApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.DependencyResolver = new NinjectResolver();

            config.MapHttpAttributeRoutes();

            /*config.Routes.MapHttpRoute(
                    name: "Api with extension",
                    routeTemplate: "api/{controller}.{ext}/{id}",
                    defaults: new { id = RouteParameter.Optional, ext = RouteParameter.Optional }
                );*/

            config.Routes.MapHttpRoute(
                    name: "Binding Example Route",
                    routeTemplate: "api/{controller}/{action}/{first}/{second}"
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /*MediaTypeFormatter xmlFormatter = config.Formatters.XmlFormatter;
            config.Formatters.Remove(xmlFormatter);
            config.Formatters.Insert(0, xmlFormatter);

            JsonMediaTypeFormatter jsonForm = config.Formatters.JsonFormatter;
            jsonForm.Indent = true;
            jsonForm.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
            jsonForm.SerializerSettings.StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.EscapeHtml;
            jsonForm.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;*/

            //config.Services.Replace(typeof(IContentNegotiator), new CustomNegotiator());
            //MediaTypeFormatter prodFormatter = new ProductFormatter();
            //prodFormatter.AddQueryStringMapping("format", "product", "application/x.product");
            //prodFormatter.AddRequestHeaderMapping("X-UseProductFormat","true",StringComparison.InvariantCultureIgnoreCase, false, "application/x.product");
            //prodFormatter.AddUriPathExtensionMapping("custom", "application/x.product");
            //config.Formatters.Add(prodFormatter);

            config.ParameterBindingRules.Insert(0, typeof(Numbers), x => x.BindWithAttribute(new FromUriAttribute()));
        }
    }
}

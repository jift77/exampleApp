using ExampleApp.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

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

            config.Routes.MapHttpRoute(
                    name: "Api with extension",
                    routeTemplate: "api/{controller}.{ext}/{id}",
                    defaults: new { id = RouteParameter.Optional, ext = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Services.Replace(typeof(IContentNegotiator), new CustomNegotiator());
            //MediaTypeFormatter prodFormatter = new ProductFormatter();
            //prodFormatter.AddQueryStringMapping("format", "product", "application/x.product");
            //prodFormatter.AddRequestHeaderMapping("X-UseProductFormat","true",StringComparison.InvariantCultureIgnoreCase, false, "application/x.product");
            //prodFormatter.AddUriPathExtensionMapping("custom", "application/x.product");
            //config.Formatters.Add(prodFormatter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace ExampleApp.Infraestructure
{
    public class HeaderValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            if (actionContext.Request.Method == HttpMethod.Post)
            {
                return new HeaderValueProvider(new HeadersMap(actionContext.Request.Headers));
            }
            else
                return null;
        }
    }
}
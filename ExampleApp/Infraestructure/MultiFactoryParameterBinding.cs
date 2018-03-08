using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.ValueProviders;

namespace ExampleApp.Infraestructure
{
    public class MultiFactoryParameterBinding : HttpParameterBinding
    {
        public MultiFactoryParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor)
        {

        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            foreach (ValueProviderFactory factory in GlobalConfiguration.Configuration.Services.GetValueProviderFactories())
            {
                if (factory is HeaderValueProviderFactory || factory is IUriValueProviderFactory) {
                    IValueProvider provider = factory.GetValueProvider(actionContext);
                    ValueProviderResult result = null;
                    if (provider != null && (result = provider.GetValue(Descriptor.ParameterName)) != null)
                    {
                        SetValue(actionContext, result.RawValue);
                        break;
                    }
                }
            }
            return Task.FromResult<object>(null);
        }
    }
}
using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders.Providers;
using System.Globalization;

namespace ExampleApp.Infraestructure
{
    public class UrlNumbersFormatter : MediaTypeFormatter
    {
        public override bool CanReadType(Type type)
        {
            return type == typeof(Numbers);
        }

        public override bool CanWriteType(Type type) => false;

        public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            FormDataCollection fd = (FormDataCollection)await base.ReadFromStreamAsync(typeof(FormDataCollection), readStream, content, formatterLogger);
            /*HttpActionContext actionContext = new HttpActionContext();
            ModelMetadata md = GlobalConfiguration.Configuration.Services.GetModelMetadataProvider().GetMetadataForType(null, type);
            ModelBindingContext bindingContext = new ModelBindingContext { ModelMetadata = md, ValueProvider = new NameValuePairsValueProvider(fd, CultureInfo.InvariantCulture) };

            if (new NumbersBinder().BindModel(actionContext, bindingContext))
                return bindingContext.Model;

            return null;*/

            return new Numbers(
                GetValue<int>("First", fd, formatterLogger),
                GetValue<int>("Second", fd, formatterLogger))
                        {
                            Op = new Operation
                            {
                                Add = GetValue<bool>("Add", fd, formatterLogger),
                                Double = GetValue<bool>("Double", fd, formatterLogger)
                            }
                        };
        }

        private T GetValue<T>(string name, FormDataCollection fd,IFormatterLogger logger)
        {
            T result = default(T);
            try
            {
                result = (T)System.Convert.ChangeType(fd[name], typeof(T));
            }
            catch
            {
                logger.LogError(name, "Cannot Parse Value");
            }
            return result;
        }
    }
}
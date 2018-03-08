using System.Web.Http;
using System.Web.Http.Controllers;

namespace ExampleApp.Infraestructure
{
    public class FromHeaderAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new HeaderValueParameterBinding(parameter);
        }
    }
}
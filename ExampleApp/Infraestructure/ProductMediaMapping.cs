using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;

namespace ExampleApp.Infraestructure
{
    public class ProductMediaMapping : MediaTypeMapping
    {
        public ProductMediaMapping() : base("application/x.product")
        {
                
        }

        public override double TryMatchMediaType(HttpRequestMessage request)
        {
            IEnumerable<string> values;
            return request.Headers.TryGetValues("X-UseProductFormat", out values) && values.Where(X => X == "true").Count() > 0 ? 1 : 0;
        }
    }
}
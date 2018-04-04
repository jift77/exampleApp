using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExampleApp.Infraestructure
{
    public class ProductFormatter : MediaTypeFormatter
    {
        private string controllerName;

        public ProductFormatter()
        {
            //SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/x.product"));
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedEncodings.Add(Encoding.UTF8);
            MediaTypeMappings.Add(new ProductMediaMapping());
        }

        public ProductFormatter(string controllerArg) : this()
        {
            controllerName = controllerArg;
        }

        public override bool CanReadType(Type type) => false;

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Product) || type == typeof(IEnumerable<Product>);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            List<string> productStrings = new List<string>();
            IEnumerable<Product> products = value is Product ? new Product[] { (Product)value } : (IEnumerable<Product>)value;
            foreach (Product product in products)
            {
                var name = controllerName == null ? product.Name : $"{product.Name} ({controllerName})";
                productStrings.Add($"{product.ProductID},{name},{product.Price}");
            }
            Encoding enc = SelectCharacterEncoding(content.Headers);
            StreamWriter writer = new StreamWriter(writeStream, enc ?? Encoding.Unicode);
            await writer.WriteAsync(string.Join(",", productStrings));
            writer.Flush(); 
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.Add("X-ModelType", type == typeof(IEnumerable<Product>) ? "IEnumerable<Product>" : "Product");
            headers.Add("X-ModelType", mediaType.MediaType);
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            return new ProductFormatter(request.GetRouteData().Values["controller"].ToString());
        }

         
    }
}
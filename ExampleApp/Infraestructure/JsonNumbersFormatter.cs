using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ExampleApp.Infraestructure
{
    public class JsonNumbersFormatter : MediaTypeFormatter
    {
        long bufferSize = 256;

        public JsonNumbersFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/json"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(Numbers);
        }

        public override bool CanWriteType(Type type) => false;

        public async override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            byte[] buffer = new byte[Math.Min(content.Headers.ContentLength.Value, bufferSize)];
            string jsonString = Encoding.Default.GetString(buffer, 0, await readStream.ReadAsync(buffer, 0, buffer.Length));
            JObject jdata = JObject.Parse(jsonString);
            return new Numbers((int)jdata["first"], (int)jdata["second"]) {
                Op = new Operation {
                    Add = (bool)jdata["op"]["add"],
                    Double = (bool)jdata["op"]["double"]
                }
            };
        }
    }
}
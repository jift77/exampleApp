using ExampleApp.Models;
using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace ExampleApp.Infraestructure
{
    public class XNumbersFormatter : MediaTypeFormatter
    {
        long buffersize = 256;

        public XNumbersFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x.product"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(Numbers);
        }

        public override bool CanWriteType(Type type) => false;

        public async override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            byte[] buffer = new byte[Math.Min(content.Headers.ContentLength.Value, buffersize)];
            string[] items = Encoding.Default.GetString(buffer, 0, await readStream.ReadAsync(buffer, 0, buffer.Length)).Split(',', '=');
            if (items.Length == 4)
            {
                return new Numbers(
                    GetValue<int>("first", items[0], formatterLogger),
                    GetValue<int>("second", items[1], formatterLogger))
                {
                    Op = new Operation {
                        Add = GetValue<bool>("Add", items[2], formatterLogger),
                        Double = GetValue<bool>("Double", items[3], formatterLogger) }
                };
            }
            else
            {
                formatterLogger.LogError("", "Wrong number of items");
                return null;
            }
        }

        private T GetValue<T>(string name, string value, IFormatterLogger logger)
        {
            T result = default(T);
            try
            {
                result = (T)System.Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                logger.LogError(name, "Cannot Parse Value");
            }
            return result;
        }
    }
}
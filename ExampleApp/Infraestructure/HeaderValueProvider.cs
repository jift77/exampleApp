﻿using System.Globalization;
using System.Linq;
using System.Web.Http.ValueProviders;

namespace ExampleApp.Infraestructure
{
    public class HeaderValueProvider : IValueProvider
    {
        private HeadersMap headers;

        public HeaderValueProvider(HeadersMap map)
        {
            headers = map;
        }

        public bool ContainsPrefix(string prefix) => false;

        public ValueProviderResult GetValue(string key)
        {
            string value = headers[key.Split('.').Last()];
            return value == null ? null : new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
        }
    }
}
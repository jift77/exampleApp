using ExampleApp.Infraestructure;
using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace ExampleApp.Controllers
{
    public class BindingsController : ApiController
    {
        private IRepository repo;

        public BindingsController(IRepository rep)
        {
            repo = rep;
        }

        [HttpGet]
        [HttpPost]
        public string SumNumbers([ModelBinder] Numbers numbers)
        {
            var result = numbers.Op.Add
            ? numbers.First + numbers.Second
            : numbers.First - numbers.Second;
            return string.Format("{0} (Accept:{1})",
            numbers.Op.Double ? result * 2 : result, numbers.Accept);
        }
    }
}

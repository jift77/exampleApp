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
        public string SumNumbers(Numbers numbers,string accept)   
        {
            return string.Format("{0} (Accept: {1})", numbers.First + numbers.Second, accept);
        }
    }
}

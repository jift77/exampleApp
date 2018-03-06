using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

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
        public int SumNumbers(Numbers numbers)
        {
            return numbers.First + numbers.Second;
        }
    }
}

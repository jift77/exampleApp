using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleApp.Controllers
{
    public class FormatsController : ApiController
    {
        public DataObject getData() {
            return new DataObject
            {
                Time = DateTime.Now,
                Text = "Joe <b>Smith</b>",
                Count = 0
            };
        }
    }

    public class DataObject {
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public int Count { get; set; }
    }
}

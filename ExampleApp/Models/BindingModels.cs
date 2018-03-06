using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleApp.Models
{
    public class Numbers 
    {
        public int First { get; set; }
        public int Second { get; set; }
    }

    public class Operation
    {
        public bool Add { get; set; }
        public bool Double { get; set; }
    }
}
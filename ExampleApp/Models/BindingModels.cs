using ExampleApp.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace ExampleApp.Models
{
    //[ModelBinder(binderType:typeof(NumbersBinder))]
    //[TypeConverter(typeof(NumbersTypeConverter))]
    public class Numbers
    {
        public Numbers() { /* do nothing */ }
        public Numbers(int first, int second)
        {
            First = first; Second = second;
        }
        public int First { get; set; }
        public int Second { get; set; }
        public Operation Op { get; set; }
        public string Accept { get; set; }
    }

    public class Operation
    {
        public bool Add { get; set; }
        public bool Double { get; set; }
    }
}
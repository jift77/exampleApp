using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleApp.Models
{
    public class Numbers 
    {
        private int first, second;
        public Numbers(int firstVal, int secondVal)
        {
            first = firstVal; second = secondVal;
        }
        public int First
        {
            get { return first; }
        }
        public int Second
        {
            get { return second; }
        }

        public Operation Op { get; set; }
        public string Accept { get; set; }
    }

    public class Operation
    {
        public bool Add { get; set; }
        public bool Double { get; set; }
    }
}
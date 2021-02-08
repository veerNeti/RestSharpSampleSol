using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharp_Demo.Model
{
    public class ResponseClass
    {
        public Data data {get;set;}
        public Support support { get; set; }

        public override string ToString()
        {
            return "data:\t"+ data.ToString()+ "\nSupport:\t"+support.ToString();
        }
    }
}

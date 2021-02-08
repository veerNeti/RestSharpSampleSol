using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RestSharp_Demo.Model
{
    public class Root
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Data> Data { get; set; }
        public Support Support { get; set; }

        public override string ToString()
        {
            return "\nData: " + Data.ToString() + "\n Support:" + Support.ToString(); ;
        }
    }
}

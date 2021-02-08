using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharp_Demo.Model
{
   public class Equipment
    {
        public int TripID { get; set; }
        public bool LoadStatus { get; set; }
        public int Tractor { get; set; }
        public int Trailer { get; set; }
        public int LoadWeight { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ETA { get; set; }
    }
}

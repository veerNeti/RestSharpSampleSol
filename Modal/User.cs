using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestSharp_Demo.Model
{
    public class User
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("job")]
        public string job { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

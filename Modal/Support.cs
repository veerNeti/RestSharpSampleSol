using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RestSharp_Demo.Model
{
    public class Support
    {
        [JsonProperty("url")]
        public string Url;

        [JsonProperty("text")]
        public string Text;
    }
}

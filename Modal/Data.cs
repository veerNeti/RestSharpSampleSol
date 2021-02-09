using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestSharp_Demo.Model
{
    public class Data
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("first_name")]
        public string FirstName;

        [JsonProperty("last_name")]
        public string LastName;

        [JsonProperty("avatar")]
        public string Avatar;
    }
}

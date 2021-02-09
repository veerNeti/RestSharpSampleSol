using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RestSharp_Demo.Model
{
    public class Root
    {
        [JsonProperty("page")]
        public int Page;

        [JsonProperty("per_page")]
        public int PerPage;

        [JsonProperty("total")]
        public int Total;

        [JsonProperty("total_pages")]
        public int TotalPages;

        [JsonProperty("data")]
        public List<Data> Data;

        [JsonProperty("support")]
        public Support Support;
    }


}

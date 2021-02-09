using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp_Demo.Model;

namespace SampleRestSharp.Steps
{
    //context injection
    public class SetConfig
    {
        public User user { get; set; }
        public Uri baseUrl { get; set; }
        public RestClient restClient { get; set; } = new RestClient();
        public IRestRequest restRequest { get; set; }
        public IRestResponse<User> restResponseUser { get; set; }
        public IRestResponse restResponse { get; set; }
    }
}

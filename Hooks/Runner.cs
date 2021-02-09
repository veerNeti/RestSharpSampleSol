using System;
using System.Collections.Generic;
using System.Text;
using SampleRestSharp.Steps;
using TechTalk.SpecFlow;

namespace SampleRestSharp.Hooks
{
    [Binding]
    public class Runner
    {
        private SetConfig _set;

        public Runner(SetConfig set)
        {
            _set = set;
        }
        [BeforeScenario]
        public void Setup()
        {
            _set.baseUrl= new Uri("https://reqres.in/api/");
            _set.restClient.BaseUrl = _set.baseUrl;
        }
    }
}

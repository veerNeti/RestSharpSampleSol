using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using RestSharp_Demo.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpSampleProject.Steps
{
    [Binding]
    public class RestAPIMethodSteps
    {
        private User _user;
        private Uri _baseUrl;
        private RestClient _restClient;
        private RestRequest _restRequest;
        private IRestResponse<User> _restResponse;

        public RestAPIMethodSteps()
        {
            _user = new User();
            _baseUrl = new Uri("https://reqres.in/api/");
        }
        [Given(@"the availability if a reqres service")]
        public void GivenTheAvailabilityIfAReqresService()
        {
            _restClient = new RestClient(_baseUrl);
        }
        
        [Given(@"resource/payload to create a new user")]
        public void GivenResourcePayloadToCreateANewUser(Table table)
        {
            _user = table.CreateInstance<User>();
        }
        
        [When(@"I post the payload to the service")]
        public void WhenIPostThePayloadToTheService()
        {
            _restRequest = new RestRequest("users", Method.POST);
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddJsonBody(_user);
            _restResponse = _restClient.ExecutePostAsync<User>(_restRequest).GetAwaiter().GetResult();
        }

        private UserResponse _userResponse;
        [Then(@"the user information is persisted")]
        public void ThenTheUserInformationIsPersisted()
        {
            string content = _restResponse.Content;
            _userResponse = JsonConvert.DeserializeObject<UserResponse>(content);
            Assert.IsTrue(_userResponse.name.ToLower().Equals(_user.name));
        }
        
        [Then(@"user id is assigned with a create date")]
        public void ThenUserIdIsAssignedWithACreateDate()
        {
            Assert.IsTrue(int.Parse(_userResponse.id.ToString())!=null);
        }
    }
}

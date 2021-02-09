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
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse<User> _restResponse;
        private IRestResponse restResponse;

        public RestAPIMethodSteps()
        {
            _user = new User();
            _baseUrl = new Uri("https://reqres.in/api/");
        }


        [Given(@"the availability of a ""(.*)"" reqres service")]
        public void GivenTheAvailabilityOfAReqresService(string p0)
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
            Assert.IsTrue(_userResponse.name.ToLower().Equals(_user.name.ToLower()));
        }

        [Then(@"user id is assigned with a create date")]
        public void ThenUserIdIsAssignedWithACreateDate()
        {
            Assert.IsTrue(int.Parse(_userResponse.id.ToString()) != null);
        }


        [When(@"we get a list of users in page ""(.*)""")]
        public void WhenWeGetAListOfUsersInPage(int p0)
        {
            /*      {https://reqres.in/api/users/{entity}?entity=2}
                  https://reqres.in/api/users?page=2
            */
            _restRequest = new RestRequest("users").AddParameter("page", p0);
            restResponse = _restClient.ExecuteGetTaskAsync(_restRequest).GetAwaiter().GetResult();

        }

        [Then(@"validate the response from ExecuteGetTaskAsync")]
        public void ThenValidateTheResponseFromExecuteGetTaskAsync()
        {
            string content = restResponse.Content;
            Root root = JsonConvert.DeserializeObject<Root>(content);

            Assert.IsTrue(restResponse.ErrorMessage == null);
            Assert.IsTrue(restResponse.IsSuccessful);

            Assert.IsTrue(root.Data.Count > 0);
        }



        [When(@"we get a single user ""(.*)""")]
        public void WhenWeGetASingleUser(int p0)
        {
            /* 
                https://reqres.in/api/users/2
            */
            _restRequest = new RestRequest("users/{value}").AddUrlSegment("value", p0);
            restResponse = _restClient.ExecuteTaskAsync(_restRequest).GetAwaiter().GetResult();

        }

        [Then(@"validate the response from ExecuteAsyncReq")]
        public void ThenValidateTheResponseFromExecuteAsyncReq()
        {
            string content = restResponse.Content;
            ResponseClass root = JsonConvert.DeserializeObject<ResponseClass>(content);

            Assert.IsTrue(restResponse.ErrorMessage == null);
            Assert.IsTrue(restResponse.IsSuccessful);

            Assert.IsTrue(root.data != null);
        }
        
        [When(@"i ""(.*)"" a user ""(.*)"" record information")]
        public void WhenIAUserRecordInformation(string method, int param)
        {
            switch (method.ToUpper())
            {
                case "PUT":
                    /*  
                     * https://reqres.in/api/users/2
                     */
                    _restRequest = new RestRequest("users/{resource}", Method.PUT).AddUrlSegment("resource", param);
                    break;
                case "PATCH":
                    _restRequest = new RestRequest("users/{resource}", Method.PATCH).AddUrlSegment("resource", param);
                    break;

                default:
                    break;
            }
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddJsonBody(_user);
            _restResponse = _restClient.ExecutePostAsync<User>(_restRequest).GetAwaiter().GetResult();
        }

    }
}

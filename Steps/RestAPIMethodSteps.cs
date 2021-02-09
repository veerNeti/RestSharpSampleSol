using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using RestSharp_Demo.Model;
using SampleRestSharp.Steps;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpSampleProject.Steps
{
    [Binding]
    public class RestAPIMethodSteps
    {
        private SetConfig _setConfig;

        public RestAPIMethodSteps(SetConfig set)
        {
            _setConfig = set;
        }


        [Given(@"the availability of a ""(.*)"" reqres service")]
        public void GivenTheAvailabilityOfAReqresService(string p0)
        {
            _setConfig.restClient = new RestClient(_setConfig.baseUrl);
        }

        [Given(@"resource/payload to create a new user")]
        public void GivenResourcePayloadToCreateANewUser(Table table)
        {
            _setConfig.user = table.CreateInstance<User>();
        }

        [When(@"I post the payload to the service")]
        public void WhenIPostThePayloadToTheService()
        {
            _setConfig.restRequest = new RestRequest("users", Method.POST);
            _setConfig.restRequest.RequestFormat = DataFormat.Json;
            _setConfig.restRequest.AddJsonBody(_setConfig.user);
            _setConfig.restResponseUser = _setConfig.restClient.ExecutePostAsync<User>(_setConfig.restRequest).GetAwaiter().GetResult();
        }

        private UserResponse _userResponse;
        [Then(@"the user information is persisted")]
        public void ThenTheUserInformationIsPersisted()
        {
            string content = _setConfig.restResponseUser.Content;
            _userResponse = JsonConvert.DeserializeObject<UserResponse>(content);
            Assert.IsTrue(_userResponse.name.ToLower().Equals(_setConfig.user.name.ToLower()));
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
            _setConfig.restRequest = new RestRequest("users").AddParameter("page", p0);
            _setConfig.restResponse = _setConfig.restClient.ExecuteGetTaskAsync(_setConfig.restRequest).GetAwaiter().GetResult();

        }

        [Then(@"validate the response from ExecuteGetTaskAsync")]
        public void ThenValidateTheResponseFromExecuteGetTaskAsync()
        {
            string content = _setConfig.restResponse.Content;
            Root root = JsonConvert.DeserializeObject<Root>(content);

            Assert.IsTrue(_setConfig.restResponse.ErrorMessage == null);
            Assert.IsTrue(_setConfig.restResponse.IsSuccessful);

            Assert.IsTrue(root.Data.Count > 0);
        }



        [When(@"we get a single user ""(.*)""")]
        public void WhenWeGetASingleUser(int p0)
        {
            /* 
                https://reqres.in/api/users/2
            */
            _setConfig.restRequest = new RestRequest("users/{value}").AddUrlSegment("value", p0);
            _setConfig.restResponse = _setConfig.restClient.ExecuteTaskAsync(_setConfig.restRequest).GetAwaiter().GetResult();

        }

        [Then(@"validate the response from ExecuteAsyncReq")]
        public void ThenValidateTheResponseFromExecuteAsyncReq()
        {
            string content = _setConfig.restResponse.Content;
            ResponseClass root = JsonConvert.DeserializeObject<ResponseClass>(content);

            Assert.IsTrue(_setConfig.restResponse.ErrorMessage == null);
            Assert.IsTrue(_setConfig.restResponse.IsSuccessful);

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
                    _setConfig.restRequest = new RestRequest("users/{resource}", Method.PUT).AddUrlSegment("resource", param);
                    break;
                case "PATCH":
                    _setConfig.restRequest = new RestRequest("users/{resource}", Method.PATCH).AddUrlSegment("resource", param);
                    break;

                default:
                    break;
            }
            _setConfig.restRequest.RequestFormat = DataFormat.Json;
            _setConfig.restRequest.AddJsonBody(_setConfig.user);
            _setConfig.restResponseUser = _setConfig.restClient.ExecutePostAsync<User>(_setConfig.restRequest).GetAwaiter().GetResult();
        }

    }
}

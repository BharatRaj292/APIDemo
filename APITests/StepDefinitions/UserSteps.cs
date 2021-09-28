using APIDemo;
using APIDemo.DTO;
using APIDemo.Models.Requests;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace APITests.StepDefinitions
{
    [Binding]
    public class UsersSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly ListOfUsersModel listOfUsersModel;
        private IRestResponse response;

        public UsersSteps(ListOfUsersModel listOfUsersModel)
        {
            this.listOfUsersModel = listOfUsersModel;
        }

        [Given(@"This is Get Request")]
        public void GivenThisIsGetRequest()
        {
            
        }
        
        [When(@"I send get Users request")]
        public void WhenISendGetUsersRequest()
        {
            var api = new API<ListOfUsersDTO>();
            response = api.getUsers(BASE_URL, "api/users?page=2");
        }
        
        [Then(@"Verify Status code should be ""(.*)""")]
        public void ThenVerifyStatusCodeShouldBe(int status)
        {
            
            var statusCode = (int)response.StatusCode;
            Assert.AreEqual(status, statusCode);
        }
        
        [Then(@"Verify FirstName should be ""(.*)""")]
        public void ThenVerifyFirstNameShouldBe(string firstName)
        {
            string url = "https://github.com/";
            string client_id = "client_id";
            string client_secret = "client_secret";
            //request token
            var restclient = new RestClient(url);
            RestRequest request = new RestRequest("request/oauth") { Method = Method.POST };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", client_id);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("grant_type", "client_credentials");
            var tResponse = restclient.Execute(request);
            var responseJson = tResponse.Content;
            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();
            return token.Length > 0 ? token : null;

            var content = HandleContent.getContent<ListOfUsersDTO>(response);
            Assert.AreEqual(firstName, content.Data[0].first_name);
        }

    }
}

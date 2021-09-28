using APIDemo;
using APIDemo.DTO;
using APIDemo.Models.Requests;
using NUnit.Framework;
using RestSharp;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace APITests.StepDefinitions
{
    [Binding]
    public class CreateUserSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUserModel createUserModel;
        private IRestResponse response;

        public CreateUserSteps(CreateUserModel createUserModel)
        {
            this.createUserModel = createUserModel;
        }

        [Given(@"I input name ""(.*)""")]
        public void GivenIInputName(string name)
        {
            createUserModel.Name = name;
        }
        
        [Given(@"I Input role ""(.*)""")]
        public void GivenIInputRole(string role)
        {
            createUserModel.Job = role;
        }
        
        [When(@"I send create user request")]
        public void WhenISendCreateUserRequest()
        {
            var api = new API<CreateUserDTO>();
            response = api.createUser(BASE_URL, "api/users", createUserModel);


        }
        
        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandleContent.getContent<CreateUserDTO>(response);
            Assert.AreEqual(createUserModel.Name, content.Name);
            Assert.AreEqual(createUserModel.Job, content.Job);

        }

        [Given(@"I send createUser request  (.*)")]
        public void GivenISendCreateUserRequest(string payload)
        {
            var api = new API<CreateUserDTO>();
            response = api.createUser(BASE_URL, "api/users", payload);
        }

        [Given(@"I send createUserPost request :")]
        public void GivenISendCreateUserPostRequest(string multilineText)
        {
            var api = new API<CreateUserDTO>();
            var str = multilineText;
            str = str.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
            str = str.Replace(@"\", String.Empty);
            response = api.createUser(BASE_URL, "api/users", str);
        }


    }
}

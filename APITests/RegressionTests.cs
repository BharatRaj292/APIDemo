using APIDemo;
using APIDemo.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;

namespace APITests
{
    [TestClass]
    public class RegressionTests
    {
        private readonly string baseUrl = "https://reqres.in/";
        RestClient restClient;

        [TestMethod]
        public void VerifyListOfUsers()
        {
            //var demo = new Demo<ListOfUsersDTO>();
            //var response = demo.GetUsers("api/users?page=2");
            //Assert.AreEqual(2, response.Page);
            //Assert.AreEqual("Michael", response.Data[0].first_name);

           // restClient.Authenticator.Authenticate()

            var api = new API<ListOfUsersDTO>();
            var response = api.getUsers(baseUrl, "api/users?page=2");
            var statusCode = (int)response.StatusCode;
            var content = HandleContent.getContent<ListOfUsersDTO>(response);
            Assert.AreEqual(200, statusCode);
            Assert.AreEqual(2, content.Page);
            Assert.AreEqual("Michael", content.Data[0].first_name);

        }


        [TestMethod]
        public void CreateNewUserWithValidInput()
        {
            //string payload = @"{
            //                    ""name"" : ""Mike"",
            //                    ""job"" : ""Team Leader""
            //                    }";

            var payload = HandleContent.parseJson<CreateUserDTO>("CreateUser.json");

            var api = new API<CreateUserDTO>();
            var response = api.createUser(baseUrl, "api/users", payload);
            var content = HandleContent.getContent<CreateUserDTO>(response);

            Assert.AreEqual(payload.Name,content.Name);
            Assert.AreEqual(payload.Job,content.Job);
        }
    }
}

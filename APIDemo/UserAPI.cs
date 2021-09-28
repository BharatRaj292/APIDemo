using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo
{
    public class API<T>
    {
        private Helper helper;

        public API()
        {
            helper = new Helper();
        }

        public IRestResponse getUsers(string baseUrl, string endpoint)
        {
            var url = helper.CreateClient(baseUrl, endpoint);
            var request = helper.CreateGetRequest();
            var response = helper.getResponse(url, request);
            return response;
        }

        public IRestResponse createUser(string baseUrl, string endpoint,dynamic payload)
        {
            var url = helper.CreateClient(baseUrl, endpoint);
            var requestJson = HandleContent.serialize(payload);
            var request = helper.CreatePostRequest(requestJson);
            var response = helper.getResponse(url, request);
            return response;
        }


    }
}

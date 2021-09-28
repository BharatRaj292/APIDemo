using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo
{
    public static class HandleContent
    {
        public static T getContent<T>(IRestResponse response)
        {
            var _content = response.Content;
            return JsonConvert.DeserializeObject<T>(_content);
        }

        public static string serialize(dynamic payload)
        {
            return JsonConvert.SerializeObject(payload, Formatting.Indented);
        }

        public static T parseJson<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
    }
}

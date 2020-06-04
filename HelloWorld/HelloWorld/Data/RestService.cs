using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Data
{
    //These are the rest services
    public class RestService
    {

        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            
        }

        public async Task<String> Post(String title, String body, String userid)
        {
            var postData = new List<KeyValuePair<String, String>>();
            postData.Add(new KeyValuePair<string, string>("title", title));
            postData.Add(new KeyValuePair<string, string>("pasword", body));
            postData.Add(new KeyValuePair<string, string>("pasword", userid));
            var content = new  FormUrlEncodedContent(postData);
            var response = await PostResponse(content);

            return response;




        }

        public async Task<String> PostResponse(FormUrlEncodedContent content)
        {
            var weburl = "http://jsonplaceholder.typicode.com/posts";
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            
            return jsonResult;
        }

        public async Task<String> GetResponse()
        {
            var weburl = "http://jsonplaceholder.typicode.com/todos/1";
            var response = await client.GetAsync(weburl);
            var jsonResult = response.Content.ReadAsStringAsync().Result;

            return jsonResult;

        }

    }
}

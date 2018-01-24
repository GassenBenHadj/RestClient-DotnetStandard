using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RestClient_DotnetStandard
{
    // this code was created by Houssem Dellai at first,this just an adaptation to the new Xamarin strategy dotnet standard after that PCLs  was obsoleted
    public class RestClient<T>
    {
        
        public List<T> Get(string WebServiceUrl)
        {
            var httpClient = new HttpClient();

            var json = httpClient.GetStringAsync(WebServiceUrl).Result;

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public  bool Post(string WebServiceUrl,T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result =  httpClient.PostAsync(WebServiceUrl, httpContent).Result;

            return result.IsSuccessStatusCode;
        }

        public bool Put(string WebServiceUrl,int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result =  httpClient.PutAsync(WebServiceUrl + id, httpContent).Result;

            return result.IsSuccessStatusCode;
        }

        public bool Delete(string WebServiceUrl,int id, T t)
        {
            var httpClient = new HttpClient();

            var response =  httpClient.DeleteAsync(WebServiceUrl + id).Result;

            return response.IsSuccessStatusCode;
        }
    }
}

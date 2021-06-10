using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;

namespace AssurityAPIProj
{
    class BaseClass
    {
        public string baseURL = Settings1.Default.baseUrl;
        public string endPoint = Settings1.Default.endPoint;
        public RestClient SetUrl()
        {
            var url = Path.Combine(baseURL + endPoint);
            var restClient = new RestClient(url);
            return restClient;
        }

        public RestRequest CreatetGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DataList GetContent<DataListDTO>(RestResponse response)
        {
            var content = response.Content;
            DataList dtoObject = JsonConvert.DeserializeObject<DataList>(content);
            return dtoObject;
        }
    }
}

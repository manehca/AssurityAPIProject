using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssurityAPIProj
{
    public class MainClass
    {
        public DataListDTO GetDataList()
        {
            var restClient = new RestClient("https://api.tmsandbox.co.nz");
            var restRequest = new RestRequest("https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false", Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            var dataList = JsonConvert.DeserializeObject<DataListDTO>(content);
            return dataList;
        }    

    }
}

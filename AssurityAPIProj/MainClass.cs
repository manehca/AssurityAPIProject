using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AssurityAPIProj
{
    public class MainClass
    {
        public DataListDTO GetDataList()
        {
            BaseClass _baseClass = new BaseClass();
            var restClient = _baseClass.SetUrl();
            var restRequest = _baseClass.CreatetGetRequest();
            var restResponse = (RestResponse)_baseClass.GetResponse(restClient, restRequest);

            var dataList = JsonConvert.DeserializeObject<DataListDTO>(restResponse.Content);
            return dataList;
        }

        

    }
}

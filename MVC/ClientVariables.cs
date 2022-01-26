using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MVC
{
    public  class ClientVariables
    {
        public static HttpClient WebApiClient=new HttpClient();

         static ClientVariables()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44395/api/");
            WebApiClient.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            WebApiClient.DefaultRequestHeaders.Clear();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmployeeApp.init
{
    public static class GlobalVariable
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariable()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44373/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVCWEB
{
    public class GlobalVariables
    {
       public static HttpClient webclientApi = new HttpClient();

         static GlobalVariables()
        {
            webclientApi.BaseAddress = new Uri("http://localhost:50444/api/");
            webclientApi.DefaultRequestHeaders.Clear();
            webclientApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
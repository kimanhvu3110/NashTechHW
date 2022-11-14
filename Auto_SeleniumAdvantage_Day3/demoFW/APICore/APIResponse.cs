using OpenQA.Selenium.DevTools.V104.Fetch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.APICore
{
    public class APIResponse
    {
        public HttpWebResponse response;
        public string responseBody { get; set; }
        public int responseStatusCode { get; set; }

        public APIResponse(HttpWebResponse response)
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
            
        }

        private string GetResponseBody()
        {
            responseBody = "";
            using(var responseStream = response.GetResponseStream())
            {
                if(responseStream != null)
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
            }
            return responseBody;
        }

        private int GetResponseStatusCode()
        {
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)                    
                        responseStatusCode = (int)response.StatusCode;                    
            }
            return responseStatusCode;
        }
    }
}

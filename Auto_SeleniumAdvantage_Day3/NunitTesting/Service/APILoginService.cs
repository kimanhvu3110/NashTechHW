using Automation.Pages;
using CoreFramework.APICore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Automation.Service
{
    public class APILoginService
    {
        public string userLoginPath = "/userlogin";

        public APIResponse LoginRequest(string username, string password)
        {
            APIResponse response = new APIRequest()
                .setURL("https://dribbble.com" + "/login")              
                .SendRequest();
            return response;
        }

        public UserLogin LoginAPI(string username, string password)
        {
            APIResponse response = LoginRequest(username, password);
            UserLogin userLogin = (UserLogin)JsonConvert.DeserializeObject<UserLogin>(response.responseBody);
            return userLogin;

        }


    }
}

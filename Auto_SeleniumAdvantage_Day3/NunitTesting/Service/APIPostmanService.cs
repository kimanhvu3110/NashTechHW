using CoreFramework.APICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Service
{
    public class APIPostmanService
    {
        public string path = "/todos";

        public APIResponse Request1()
        {
            APIResponse response = new APIRequest()
                   .setURL("https://apichallenges.herokuapp.com" + path)
                   .SendRequest();
            return response;
        }

        public APIResponse Request2()
        {
            APIResponse response = new APIRequest().
                   setURL("https://apichallenges.herokuapp.com" + path)
                   .SetRequestParameter("doneStatus", "true")
                   .SendRequest();
            return response;
        }
    
    }
}

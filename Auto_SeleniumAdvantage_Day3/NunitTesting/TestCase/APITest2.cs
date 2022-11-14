using Automation.ProjectTestSetup;
using Automation.Service;
using CoreFramework.APICore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.TestCase
{
    public class APITest2 : ProjectTestSetUp
    {
        [Test]
        public void APIRequestTest1()
        {
            APIResponse response = new APIPostmanService().Request1();
            Assert.AreEqual(response.responseStatusCode, 200);
        }

        [Test]
        public void APIRequestTest2()
        {
            APIResponse response = new APIPostmanService().Request2();
            Console.WriteLine(response.responseBody);
            Assert.AreEqual(response.responseStatusCode, 200);
        }

    }
}

using Automation.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CoreFramework.NUnitTestSetUp;
using Automation.Pages;
using Automation.ProjectTestSetup;
using Automation.ProjectTestSetup;
using CoreFramework.APICore;
using Automation.Service;

namespace Automation.TestCase
{
    [TestFixture]
    public class APITest : ProjectTestSetUp
    {
        [Test]
        public void APIRequestTest()
        {
            APIResponse response = new APILoginService().LoginRequest("kim3122", "abc1234@@");
            Assert.AreEqual(response.responseStatusCode, 200);
        }
    }
}

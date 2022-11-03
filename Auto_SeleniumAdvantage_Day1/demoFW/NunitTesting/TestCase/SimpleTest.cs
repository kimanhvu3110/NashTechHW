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

namespace TestCase

{
    [TestFixture]
    public class SimpleTests : ProjectTestSetUp
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserCanSearchVideo()

        {
            HomePage homePage = new HomePage(_driver);
            homePage.InputSearchBox("ABC");
            homePage.Click("//input[@id='search']");

            homePage.CheckTitle("ABC");

            //loginPage loginPage = new loginPage(_driver);
            //loginPage.inputUserName("test");
        }
    }
}
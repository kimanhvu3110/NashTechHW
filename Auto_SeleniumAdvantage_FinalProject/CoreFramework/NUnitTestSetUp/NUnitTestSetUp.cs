using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CoreFramework.DriverCore;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports.Reporter;
using CoreFramework.Reporter;
using CoreFramework.DriverCore;


namespace CoreFramework.NUnitTestSetUp
{
    [TestFixture]
    public class NUnitTestSetUp
    {
        protected IWebDriver? _driver;
        public WebDriverAction driverBaseAction;
        protected ExtentReports? _extentReport;
        protected ExtentTest? _extentTestSuite;
        protected ExtentTest? _extentTestCase;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {      
            HtmlReport.CreateTest(TestContext.CurrentContext.Test.ClassName);
        }

        [SetUp]
        public void SetUp()
        {
            /*WebDriverManager.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager.GetCurrentDriver();
            driverBaseAction = new WebDriverAction(_driver);
            _extentTestCase = _extentTestSuite.CreateNode($"{TestContext.CurrentContext.Test.Name}");*/
            HtmlReport.CreateNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
            WebDriverManager.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager.GetCurrentDriver();
        }

        [TearDown]
        public void TearDown()
        {          
            _driver?.Quit();
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
                TestContext.WriteLine("passed");
            }
            else if (testStatus.Equals(TestStatus.Failed))
            {
                TestContext.WriteLine("failed");
            }
            HtmlReport.Flush();
        }
    }
}
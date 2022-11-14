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
            /* _extentReport = new ExtentReports();
             string reportPath = TestContext.CurrentContext.TestDirectory;
             var reporter = new ExtentHtmlReporter($"{reportPath}\\Reports\\Report-{DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss")}");
             _extentReport.AttachReporter(reporter);
             _extentTestSuite = _extentReport.CreateTest($"{TestContext.CurrentContext.Test.ClassName}");*/
            HtmlReport.createTest(TestContext.CurrentContext.Test.ClassName);

        }

        [SetUp]
        public void SetUp()
        {
            /*WebDriverManager.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager.GetCurrentDriver();
            driverBaseAction = new WebDriverAction(_driver);
            _extentTestCase = _extentTestSuite.CreateNode($"{TestContext.CurrentContext.Test.Name}");*/
            HtmlReport.createNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
            WebDriverManager.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager.GetCurrentDriver();
        }
        [TearDown]
        public void TearDown()
        {
            /*_driver?.Quit();
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
                //_extentTestCase.Equals()
                //TestContext.WriteLine("Passed");
                _extentTestCase?.Pass($"[Passed] Test {TestContext.CurrentContext.Test.Name}");
            }
            else if (testStatus.Equals(TestStatus.Failed))
            {
                //TestContext.WriteLine("Failed");
                _extentTestCase?.Fail($"[Failed] Test {TestContext.CurrentContext.Test.Name} because the error - {TestExecutionContext.CurrentContext}");
                //driverBaseAction.CaptureScreen();
            }
            _extentReport.Flush();*/
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
            HtmlReport.flush();
        }
    }
}
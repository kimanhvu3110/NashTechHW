using NUnit.Framework;
using NUnit.Framework.Internal;
using Automation.ProjectTestSetup;
using Automation.Common;
using Automation.Pages;
using Automation.DAO;
using OpenQA.Selenium;

namespace TestCase

{
    [TestFixture]
    public class Scenario1 : ProjectTestSetUp
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ID1_VerifyDefaultInfo()
        {
            CommonFlow.GetWebTableFlow(_driver);
            WebTablePage webTablePage = new WebTablePage(_driver);
            webTablePage.CompareTestData(3);
        }     
    }
}
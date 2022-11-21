using Automation.Common;
using Automation.Pages;
using Automation.ProjectTestSetup;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase
{
    public class Scenario2 : ProjectTestSetUp
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ID2_CreateNewEmployee()
        {
            CommonFlow.getWebTableFlow(_driver);
            WebTablePage webTablePage = new WebTablePage(_driver);
            webTablePage.clickOnAddButton();
            webTablePage.inputNewValidUser();
            webTablePage.clickOnSubmitButton();
            webTablePage.compareInputWithData();
        }
    }
}

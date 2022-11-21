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
    public class Scenario3 : ProjectTestSetUp
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ID3_UpdateEmployee()
        {
            //Update employee with required name
            CommonFlow.GetWebTableFlow(_driver);
            WebTablePage webTablePage = new WebTablePage(_driver);
            webTablePage.UpdateEmployee("Kierra");
            webTablePage.ClickOnSubmitButton();
            webTablePage.CompareInputWithData3();
            webTablePage.ClickOnDeleteButton();          
        }
    }
}

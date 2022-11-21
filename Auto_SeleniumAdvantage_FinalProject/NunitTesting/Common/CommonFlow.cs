using Automation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.ProjectTestSetup;

namespace Automation.Common
{
    public class CommonFlow 
    {
        public static void GetWebTableFlow(IWebDriver _driver)
        {
            HomePage headerPage = new HomePage(_driver);
            headerPage.GoElementPage();
            ElementPage elementPage = new ElementPage(_driver);
            elementPage.VerifyCurrentURL();
            elementPage.selectOnMenuBar();
            WebTablePage webTablePage = new WebTablePage(_driver);
            webTablePage.VerifyDisplayedScreen();
        }
    }
}

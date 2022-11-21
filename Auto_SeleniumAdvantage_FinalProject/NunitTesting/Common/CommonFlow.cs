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
        public static void getWebTableFlow(IWebDriver _driver)
        {
            HomePage headerPage = new HomePage(_driver);
            headerPage.goElementPage();
            ElementPage elementPage = new ElementPage(_driver);
            elementPage.verifyCurrentURL();
            elementPage.selectOnMenuBar();
            WebTablePage webTablePage = new WebTablePage(_driver);
            webTablePage.verifyDisplayedScreen();
        }
    }
}

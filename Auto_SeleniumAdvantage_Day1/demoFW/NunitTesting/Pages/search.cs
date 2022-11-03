
using Automation.Pages;
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
using CoreFramework.DriverCore;

namespace Automation.Pages
{

    [TestFixture]
    internal class FirstResultPage : WebDriverAction
    {
        public FirstResultPage(IWebDriver? driver) : base(driver)
        {
        }
        public void FirstResult(string a)
        {
            Thread.Sleep(3000);

            IWebElement SearchResult = FindElementByXpath(a);
            //IWebElement searchButton = _driver.FindElement(By.XPath(target_xpath));
            SearchResult.Click();


        }

    }

}


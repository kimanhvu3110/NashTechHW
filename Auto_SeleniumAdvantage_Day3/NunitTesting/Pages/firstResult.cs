
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
        private readonly String tFirstResult = "//h3/a[1]";
        public FirstResultPage(IWebDriver? driver) : base(driver)
        {
        }
        public void FirstResult()
        {
            Thread.Sleep(3000);
            string nextPage = driver.FindElement(By.XPath(tFirstResult)).GetAttribute("href");
            driver.Navigate().GoToUrl(nextPage);            
        }

        
    }

}


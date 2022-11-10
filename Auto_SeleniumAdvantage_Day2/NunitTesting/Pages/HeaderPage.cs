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

namespace Automation.Pages
{
    public class HeaderPage : WebDriverAction
    {
        protected readonly IWebDriver? _driver;
        public HeaderPage(IWebDriver? driver) : base(driver)
        {
            _driver = driver;
        }

        private readonly string searchBox = "//input[@id='search']";
        private readonly By searchButton = By.XPath("//*");

        
        public void InputSearchBox(string keyword)
        {
            SendKeys(searchBox, keyword);
        }

        public void ClickSearchButton()
        {
            SendKeys(searchBox, Keys.Enter);
        }
    }
}

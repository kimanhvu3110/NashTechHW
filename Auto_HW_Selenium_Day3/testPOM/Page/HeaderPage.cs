using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPOM.Page
{
    
    public class HeaderPage
    {
        private readonly IWebDriver? _driver;
        public HeaderPage(IWebDriver? driver)
        {
            _driver = driver;
        }

        private readonly By searchBox = By.XPath("//input[@class=\"gLFyf gsfi\"]");
        public IWebElement? GetSearchBox()
        {
            return _driver?.FindElement(searchBox);
        }

        public HeaderPage Search(string keyword)
        {
            GetSearchBox()?.Clear();
            GetSearchBox()?.SendKeys(keyword);          
            return this;
        }

        public Pages Enterp()
        {
            GetSearchBox()?.SendKeys(Keys.Enter);
            return new Pages(_driver);
        }
    }
}

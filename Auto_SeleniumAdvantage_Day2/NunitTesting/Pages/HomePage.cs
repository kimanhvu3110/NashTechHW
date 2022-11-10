using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class HomePage : HeaderPage
    {
        public HomePage(IWebDriver? driver) : base(driver)
        {
        }

        private readonly By videoTitles = By.XPath("//*[@id='video-title']");

        public IList<IWebElement>? GetVideoTitles()
        {
            return _driver?.FindElements(videoTitles);
        }


    }
}

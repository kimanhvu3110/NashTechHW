using OpenQA.Selenium;
using CoreFramework.DriverCore;
using OpenQA.Selenium.Support.UI;

namespace Automation.Pages
{
    public class HomePage : WebDriverAction
    {
        protected readonly IWebDriver? _driver;
        protected WebDriverWait _wait;
        private readonly string elementPath = "//div[contains(@class, 'card mt-4 top-card')][1]";

        public HomePage(IWebDriver? driver) : base(driver)
        {
            _driver = driver;
        }

        public void goElementPage()
        {            
            click(elementPath);                           
        }
    }
}

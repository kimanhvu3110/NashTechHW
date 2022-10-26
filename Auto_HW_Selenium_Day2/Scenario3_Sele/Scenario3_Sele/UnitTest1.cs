using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Scenario3_Sele
{
    public class Tests
    {
        protected WebDriverWait? _wait;
        protected IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            Console.WriteLine($"The website is opened successfully");
            String target_XPath = "//a[@class=\"login\"]";
            IWebElement searchResult = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(target_XPath)));
            searchResult.Click();
        }

        [Test]
        public void Test2()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            Console.WriteLine($"The website is opened successfully");
            String target_XPath = "//form[contains(@id,'searchbox')]";
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(target_XPath)));
            Console.WriteLine("hi");
        }

        [Test]//selected
        public void Test3()
        {
            
        }


    }
}
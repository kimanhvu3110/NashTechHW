using NuGet.Frameworks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using testPOM.Page;

namespace testPOM
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
        public void TestTitleSearchedPage ()
        {
            //Access to Chrome
            _driver.Navigate().GoToUrl("https://www.google.com");
            string inputt = "Waiting for you";

            //Compare title web
            Pages page = new Pages(_driver);
            HeaderPage headerPage = new HeaderPage(_driver);
            headerPage.Search(inputt);
            page = headerPage.Enterp();
            Thread.Sleep(1000);
            Assert.IsTrue(page.CompareString(inputt));

            //Verify text in next page
            _driver.Navigate().GoToUrl(page.linkToFirstResult());
            Assert.IsNotEmpty(inputt);
            //Console.WriteLine("hi");
        }
    }
}
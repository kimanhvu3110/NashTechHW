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
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://www.google.com");
            string inputt = "Waiting for you";
            Pages page = new Pages(_driver);
            HeaderPage headerPage = new HeaderPage(_driver);
            headerPage.Search(inputt);
            page = headerPage.Enterp();
            Thread.Sleep(1000);
            if(page.CompareString(inputt) == true)
            {
                Console.WriteLine("Match with title");
            }
            else
            {
                Console.WriteLine("Not match with title");
            }
            _driver.Navigate().GoToUrl(page.linkToFirstResult());
            //Console.WriteLine("hi");
        }
    }
}
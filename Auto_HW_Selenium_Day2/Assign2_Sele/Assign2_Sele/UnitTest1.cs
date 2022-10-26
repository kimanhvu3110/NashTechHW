using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Assign2_Sele
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

        //open website 
        [Test]
        public void BrowserCommandTests()
        {
            // Browser Commands
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
           
         
           
            Console.WriteLine($"The website is opened successfully");
            String target_XPath = "//*[@id=\"contact-link\"]/a";
            IWebElement searchResult = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(target_XPath)));
            searchResult.Click();
            Thread.Sleep(1000);
            String actual = _driver.Title;
            String title = "CUSTOMER SERVICE - CONTACT US";
            if (actual.Equals(title))
            {
                Console.WriteLine("Title of webpage is correct");

            }
            else
            {
                Console.WriteLine("Title of webpage is not correct");
                Console.WriteLine(actual);
            }

                _driver.Navigate().Back();
                String actual2 = _driver.Title;
                String title2 = "My Store";
                Thread.Sleep(1000);
                if (actual2.Equals(title2))
                {
                    Console.WriteLine("Title of webpage is correct");
                    Console.WriteLine(actual2);
                }
                else
                {
                    Console.WriteLine("Title of webpage is not correct");
                }
                _driver.Navigate().Forward();

            _driver.Close();
            _driver.Quit();
            
        }

    
    }
}
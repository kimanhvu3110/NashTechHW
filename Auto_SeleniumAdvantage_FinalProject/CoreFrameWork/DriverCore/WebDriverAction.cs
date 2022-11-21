using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CoreFramework.Reporter;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;


// KEYWORD-DRIVEN
namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;     
        public IJavaScriptExecutor Javascript { get; set; }
        public WebDriverAction(IWebDriver driver)
        {         
            this.driver = driver;
        }
        
        public void MoveForward()
        {
            driver.Navigate().Forward();
        }

        public void MoveBackward()
        {
            driver.Navigate().Back();
        }

        public By GetXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public string GetURL()
        {
            return driver.Url;
        }

        public string GetTextFromElement(string locator)
        {
            return driver.FindElement(By.XPath(locator)).Text;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(GetXpath(locator));
            HighlightElement(e);
            return e;
        }

        public IList<IWebElement> FindElementsByXpath(string locator)
        {
            return driver.FindElements(GetXpath(locator));
        }
       
        public void pressEnter(string locator)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(Keys.Enter);
                HtmlReport.Pass("Press enter on element [" + locator + "] passed");

            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Press enter on element [" + locator + "] failed");
                throw excep;
            }
        }

        public void clearSearchBox(string locator)
        {
            try
            {
                FindElementByXpath(locator).Clear();
                HtmlReport.Pass("Clear previous input in element [" + locator + "] passed");

            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Clear previous input in element [" + locator + "] failed");
                throw excep;
            }
        }

        public void click(IWebElement e)
        {
            try
            {
                HighlightElement(e);
                e.Click();
                HtmlReport.Pass("Clicking on element [ " + e.ToString() + " ] passed");
            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Clicking on element [ " + e.ToString() + " ] failed");
                throw excep;
            }
        }

        public void click(String locator)
        {
            try
            {
                FindElementByXpath(locator).Click();
                HtmlReport.Pass("Clicking on element [" + locator + "] passed");

            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Clicking on element [" + locator + "] failed");
                throw ex;
            }
        }

        public void doubleClick(IWebElement e)
        {
            try
            {
                WebDriverAction action = new WebDriverAction(driver);
                HighlightElement(e);
                action.doubleClick(e);
                HtmlReport.Pass("Double click on element " + e.ToString() + " successfuly");
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Double click on element " + e.ToString() + " failed with");
                throw ex;
            }
        }
        public void sendKeys_(IWebElement e, string key)
        {
            // Param IWebElem
            try
            {
                e.SendKeys(key);
                HtmlReport.Pass("Sendkey into element " + e.ToString + " successfuly", takeScreenShot());

            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Sendkey into element " + e.ToString + " failed");
                throw ex;
            }
        }

        public void sendKeys_(string locator, string key)
        {
            // Param string locator
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                HtmlReport.Pass("Sendkeys to element [" + locator + "] passed", takeScreenShot());
            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Sendkeys to element [ " + locator + " ] failed", takeScreenShot());
                throw excep;
            }
        }

        public IWebElement HighlightElement(IWebElement e)
        {
            try
            {
                IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)driver;
                string highlightJavascript = "arguments[0].style.border='2px solid red'";
                jsDriver.ExecuteScript(highlightJavascript, new object[] { e });
                HtmlReport.Pass("Highlight element [" + e.ToString() + "] passed");
                return e;

            }
            catch (Exception excep)
            {
                HtmlReport.Fail("Highlight element [" + e.ToString() + "] failed");
                throw excep;

            }
        }


        public void selectOption(string locator, string key)
        {
            try
            {
                IWebElement mySelectOption = FindElementByXpath(locator);
                SelectElement dropdown = new SelectElement(mySelectOption);
                dropdown.SelectByText(key);
                HtmlReport.Pass("Select element " + locator + " successfuly with " + key);
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Select element " + locator + " failed with " + key);
                throw ex;
            }
        }

        public void assert_(string actual, string expected)
        {
            try
            {
                Assert.That(actual, Is.EqualTo(expected));
                HtmlReport.Pass("Actual result [" + actual + "] " +
                    "is the same as [" + expected + "]", takeScreenShot());
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Actual result [" + actual + "] " +
                    "is not the same as [" + expected + "]", takeScreenShot());
                throw ex;

            }
        }
    
        public string takeScreenShot()
        {          
            try
            {
                string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png"; 
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(path, ScreenshotImageFormat.Png);
                HtmlReport.Pass("Take screenshot successfully");
                return path;
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Take screenshot failed");
                throw ex;
            }
        }

        public void TakeScreenshotIf404()
        {
            if (driver.Title.Contains("404"))
            {
                takeScreenShot();
                HtmlReport.Warning("Error 404 - Screenshot taken");
            }
            takeScreenShot();
        }
       
        public Boolean IsElementDisplay(string locator)
        {
            try
            {
                FindElementByXpath(locator);
                TestContext.WriteLine("screen is displayed");
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public void replaceKey_(string locator, string key)
        {
            try
            {             
                FindElementByXpath(locator).Clear();
                FindElementByXpath(locator).SendKeys(key);
                HtmlReport.Pass("Replace into element" + locator + "passed");                
            }
            catch (Exception ex)
            {               
                HtmlReport.Fail("Replace into element" + locator + "failed", takeScreenShot());
                throw ex;
            }
        }
    }
}
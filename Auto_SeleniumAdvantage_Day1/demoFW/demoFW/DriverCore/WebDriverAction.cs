using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;
        private WebDriverWait explicitWait;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            highLightElement(e);
            return e;
        }

        public IList<IWebElement> FindElementsByXpath(string locator)
        {
            return driver.FindElements(ByXpath(locator));
        }

        public IWebElement highLightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
            return element;
        }

        public void Click(IWebElement e)
        {
            try
            {
                highLightElement(e);
                e.Click();
               
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void Click(String locator)
        {
            try
            {
                
               FindElementByXpath(locator).Click();
               TestContext.Write("click into element " + locator + " passed");

            }
            catch (Exception ex)
            {
                TestContext.Write("click into element " + locator + " failed");
                throw ex;
            }
        }


        public void SendKeys(String locator, string key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);              
                TestContext.Write("sendkey " + locator + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("sendkey " + locator + " failed");
                throw ex;
            }
        }

        public void ExplicitWait(string id)
        {
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //explicitWait.Until(ExpectedConditions.ElementExists(By.Id(id)));
        }

        public void CheckTitle(string tilte)
        {
            string pageTitle = driver.Title;
            try
            {
                if (pageTitle.Equals(tilte))
                {
                    TestContext.Write("Title of page is correct");
                }
                else
                {
                    TestContext.Write("Title of page is not correct.");
                    TestContext.Write("Title of page is " + pageTitle);
                    TestContext.Write("Title of requirment " + tilte);
                }
            }
            catch (Exception ex)
            {
                TestContext.Write("CheckTitle is failed");
                throw ex;
            }

        }
        public void CaptureScreen()
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string currentDirec =  Environment.CurrentDirectory;
                screenshot.SaveAsFile(currentDirec, ScreenshotImageFormat.Png);
            }catch(Exception ex)
            {
                TestContext.Write("Can not capture screen!");
                throw ex;
            }
            
        }
    }
}

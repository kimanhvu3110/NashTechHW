using Automation.DAO;
using Automation.ProjectTestSetup;
using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    public class ElementPage : WebDriverAction
    {
        public ElementPage(IWebDriver driver) : base(driver)
        {
        }

        public readonly String webTableField = "//*[@class='text'][text()='Web Tables']";       
       
        public void verifyCurrentURL()
        {
            try
            {
                Assert.AreEqual(Constant.BASE_URL + "elements", GetURL());
                TestContext.WriteLine("Url is correct");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Url is incorrect");
                throw ex;
            }
        }

        public void selectOnMenuBar()
        {
            click(webTableField);
        }
      
    }
}

using CoreFramework.DriverCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Automation.Pages
{
    [TestFixture]
    public class loginPage : WebDriverAction
    {

        public loginPage(IWebDriver driver) : base(driver)
        {

        }
        private readonly String _username = "//input[@name='uid']";
        public void inputUserName(string UserName)
        {
            SendKeys(_username, UserName);
        }
    }
}

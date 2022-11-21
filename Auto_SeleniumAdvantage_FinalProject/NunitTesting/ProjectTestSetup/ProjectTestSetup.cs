using CoreFramework.NUnitTestSetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace Automation.ProjectTestSetup
{
    public class ProjectTestSetUp : NUnitTestSetUp
    {
        protected WebDriverWait _wait;

        [SetUp]
        public void SetUp()
        {          
            _driver.Url = Constant.BASE_URL;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }


        [TearDown]
        public void TearDown()
        {

        }
    }
}
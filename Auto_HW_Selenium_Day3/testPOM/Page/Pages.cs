using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPOM.Page
{
    public class Pages
    {
        private readonly IWebDriver? _driver;
        public Pages(IWebDriver? driver)
        {
            _driver = driver;
        }

        private readonly By link = By.XPath("//h3/a");
        public Boolean CompareString(string keyword)
        {
            string checkTitle = _driver.Title.ToString();
            //Console.WriteLine(checkTitle);
            string a = checkTitle.Substring(0, checkTitle.IndexOf("-"));
            //Console.WriteLine(a);   
            if (keyword.Equals(a.Trim()) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string linkToFirstResult()
        {
            return _driver?.FindElement(link).GetAttribute("href");          
        }
     
    }
}

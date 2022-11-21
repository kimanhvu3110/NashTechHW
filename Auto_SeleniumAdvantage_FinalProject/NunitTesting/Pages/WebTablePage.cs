using Automation.Assertion;
using Automation.DAO;
using Automation.TestData;
using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Automation.Pages
{
    public class WebTablePage : WebDriverAction
    {
        public readonly string mainHeader = "//*[@class='main-header']";

        public readonly string addButton = "//*[@id='addNewRecordButton']";
        public readonly string submitButton = "//*[@id='submit']";
        public readonly string firstName = "//*[@id='firstName']";
        public readonly string lastName = "//*[@id='lastName']";
        public readonly string email = "//*[@id='userEmail']";
        public readonly string age = "//*[@id='age']";
        public readonly string salary = "//*[@id='salary']";
        public readonly string department = "//*[@id='department']";

        public string updateButton;
        public string deleteButton;

        protected readonly WebDriverWait _wait;
        protected int numberEmp = 0;

        public WebTablePage(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void verifyDisplayedScreen()
        {
            Assert.AreEqual(IsElementDisplay(mainHeader), true);
        }

        public void clickOnAddButton()
        {
            click(addButton);
        }

        public void clickOnSubmitButton()
        {
            click(submitButton);
        }

        public EmployeeDAO? GetEmployeeInfo(int index)
        {
            String xpath = "//*[@class='rt-tr-group'][@role='rowgroup'][" + index + "]/div/div[7]/preceding-sibling::div";
            IList<IWebElement> EmployeeInfo = 
                FindElementsByXpath(xpath);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            if (EmployeeInfo.Count == 0)
            {
                return null;
            }
            return new EmployeeDAO(EmployeeInfo[0].Text, EmployeeInfo[1].Text, EmployeeInfo[2].Text, EmployeeInfo[3].Text, EmployeeInfo[4].Text, EmployeeInfo[5].Text);
        }

        public List<EmployeeDAO> GetEmployeeRowsFromWebPage(int total)
        {
            List<EmployeeDAO> tableEmp = new List<EmployeeDAO>();
            for(int i = 1; i<=total; i++)
            {
                tableEmp.Add(GetEmployeeInfo(i));
            }
            return tableEmp;
        }

        public int countRow()
        {
            int i = 1;
            int count = 0;
            while (true)
            {
                EmployeeDAO e = GetEmployeeInfo(i);               
                if (e.FirstName.Length < 2)
                {                    
                    break;
                }
                i++;
                count++;
                TestContext.WriteLine(count);
            }
            return count;
        }

        public List<EmployeeDAO> createTestData1()   
        {
            TestSceneData testData = new TestSceneData();
            return testData.createTestData1();
        }

        public void compareTestData(int total)
        {
            var curEmpList = GetEmployeeRowsFromWebPage(total);
            var dataTest = createTestData1();
            //TestContext.WriteLine(tableRows[0].toString());
            //TestContext.WriteLine(dataTest[0].toString());
            ListAsserter.AssertEmployeeLists(dataTest, curEmpList);
        }

        //-------------------------------------------------------------------
        //Scene2
        public void inputNewValidUser()
        {
            List<EmployeeDAO> list = createTestData2();
            //numberEmp = countRow();          
            //TestContext.WriteLine(numberEmp);
            var newEmp = list.ElementAt(list.Count - 1);
            sendKeys_(firstName, newEmp.FirstName);
            sendKeys_(lastName, newEmp.LastName);
            sendKeys_(email, newEmp.Email);
            sendKeys_(age, newEmp.Age);
            sendKeys_(salary, newEmp.Salary);
            sendKeys_(department, newEmp.Department);           
        }

        public List<EmployeeDAO> createTestData2()
        {
            TestSceneData testData = new TestSceneData();
            return testData.createTestData2();
        }

        public void compareInputWithData()
        {
            List<EmployeeDAO> list = createTestData2();
            EmployeeDAO newEmp = list.ElementAt(list.Count - 1);           
            numberEmp = countRow();
            EmployeeDAO curEmpList = GetEmployeeInfo(numberEmp);
            ListAsserter.AssertEmployees(newEmp, curEmpList);
        }

        //-----------------------------------------------------------------------------

        protected List<EmployeeDAO> list3 = new List<EmployeeDAO>();
        protected int index3 = 0;
        protected EmployeeDAO currentEmp;
        //Scene3
        public void updateEmployee(string name)
        {
            list3 = createTestData3();
            index3 = findIndexByName(name);
            updateButton = "//*[@class='rt-tr-group'][@role='rowgroup'][" + index3 + "]/div/div[7]/div/span[1]";
            click(updateButton);
            currentEmp = GetEmployeeInfo(index3);
            EmployeeDAO updateEmp = list3.ElementAt(index3-1);

            checkReplaceKey(firstName,currentEmp.FirstName, updateEmp.FirstName);
            checkReplaceKey(lastName,currentEmp.LastName, updateEmp.LastName);
            checkReplaceKey(email, currentEmp.Email,updateEmp.Email);
            checkReplaceKey(age, currentEmp.Age, updateEmp.Age);
            checkReplaceKey(salary, currentEmp.Salary, updateEmp.Salary);
            checkReplaceKey(department, currentEmp.Department ,updateEmp.Department);
        }

        public void checkReplaceKey(string locator, string current, string update)
        {
            if (current.Equals(update))
            {
            }
            else
            {
                replaceKey_(locator, update);
            }
        }

        public void clickOnDeleteButton()
        {
            deleteButton = "//*[@class='rt-tr-group'][@role='rowgroup'][" + index3 + "]/div/div[7]/div/span[2]";
            click(deleteButton);
        }

        public List<EmployeeDAO> createTestData3()
        {
            TestSceneData testData = new TestSceneData();
            return testData.createTestData3();
        }

        public int findIndexByName(string name)
        {
            int i = 1;
            int count = 1;
            while (true)
            {
                EmployeeDAO e = GetEmployeeInfo(i);
                TestContext.WriteLine(count);
                if (e.FirstName.Equals(name))
                {
                    break;
                }
                i++;
                count++;                
            }
            return count;
        }

        public void compareInputWithData3()
        {
            EmployeeDAO newUEmp = list3.ElementAt(index3 - 1);
            EmployeeDAO curEmp = GetEmployeeInfo(index3);
            ListAsserter.AssertEmployees(newUEmp, curEmp);
        }
    }
}

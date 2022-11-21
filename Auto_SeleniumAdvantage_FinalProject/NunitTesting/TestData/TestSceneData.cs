using Automation.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.TestData
{
    public class TestSceneData
    {      
        public List<EmployeeDAO> CreateTestData1()
        {
            List<EmployeeDAO> employeeList = new List<EmployeeDAO>();
            employeeList.Add(new EmployeeDAO("Cierra", "Vega", "39", "cierra@example.com", "10000", "Insurance"));
            employeeList.Add(new EmployeeDAO("Alden", "Cantrell", "45", "alden@example.com", "12000", "Compliance"));
            employeeList.Add(new EmployeeDAO("Kierra", "Gentry", "29", "kierra@example.com", "2000", "Legal"));
            return employeeList;
        }

        public List<EmployeeDAO> CreateTestData2()
        {
            List<EmployeeDAO> employeeList = new List<EmployeeDAO>();
            employeeList.Add(new EmployeeDAO("Cierra", "Vega", "39", "cierra@example.com", "10000", "Insurance"));
            employeeList.Add(new EmployeeDAO("Alden", "Cantrell", "45", "alden@example.com", "12000", "Compliance"));
            employeeList.Add(new EmployeeDAO("Kierra", "Gentry", "29", "kierra@example.com", "2000", "Legal"));
            employeeList.Add(new EmployeeDAO("Morbius", "Venom", "45", "vampire311@example.com", "1500", "Insurance"));
            return employeeList;
        }

        public List<EmployeeDAO> CreateTestData3()
        {
            List<EmployeeDAO> employeeList = new List<EmployeeDAO>();
            employeeList.Add(new EmployeeDAO("Cierra", "Vega", "39", "cierra@example.com", "10000", "Insurance"));
            employeeList.Add(new EmployeeDAO("Alden", "Cantrell", "45", "alden@example.com", "12000", "Compliance"));
            employeeList.Add(new EmployeeDAO("Kierra", "Gentry", "30", "vampire311@example.com", "1780", "Insurance"));
            return employeeList;
        }
    }
}

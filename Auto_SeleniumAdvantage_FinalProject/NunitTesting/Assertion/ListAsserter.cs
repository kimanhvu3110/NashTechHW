using Automation.DAO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Assertion
{
    public class ListAsserter
    {
        public static void AssertListEquals<TE, TA>(Action<TE, TA> asserter, IEnumerable<TE> expected, IEnumerable<TA> actual)
        {
            IList<TA> actualList = actual.ToList();
            IList<TE> expectedList = expected.ToList();

            Assert.True(
                actualList.Count == expectedList.Count,
                $"Lists have different sizes. Expected list: {expectedList.Count}, actual list: {actualList.Count}");
            for (var i = 0; i < expectedList.Count; i++)
            {
                try
                {
                    asserter.Invoke(expectedList[i], actualList[i]);
                }
                catch (Exception e)
                {
                    Assert.True(false, $"Assertion failed because: {e.Message}");
                }
            }
        }

        //Assert two list through object assert
        public static void AssertEmployeeLists(IEnumerable<EmployeeDAO> expectedAnimals, IEnumerable<EmployeeDAO> actualAnimals)
        {
            ListAsserter.AssertListEquals((e, a) => AssertEmployees(e, a),expectedAnimals, actualAnimals);
        }

        public static void AssertEmployees(EmployeeDAO expected, EmployeeDAO actual)
        {
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Age, actual.Age);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Salary, actual.Salary);
            Assert.AreEqual(expected.Department, actual.Department);
        }
    }
}

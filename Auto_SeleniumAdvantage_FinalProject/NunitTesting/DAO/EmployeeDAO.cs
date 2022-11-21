using Automation.Assertion;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Automation.DAO
{
    public class EmployeeDAO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }

        public EmployeeDAO(String firstName, String lastName, String age, String email, String salary, String department)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            Salary = salary;
            Department = department;
        }

        public readonly Regex ValidEmailRegex = CreateValidEmailRegex();
        public static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        public Boolean emailIsValid(string email)
        {
            Boolean isValid = ValidEmailRegex.IsMatch(email);
            return isValid;
        }

        public string toString()
        {
            return LastName + " " + FirstName + " " + Age + " " + Salary + " " + Department;
        }
     
    }
}

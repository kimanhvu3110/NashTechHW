using CoreFramework.NUnitTestSetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Automation.ProjectTestSetup
{
    public class ProjectTestSetUp : NUnitTestSetUp
    {
        [SetUp]
        public void SetUp()
        {
            //_driver.Url = "https://dribbble.com/login"; //for apitest
            _driver.Url = "https://apichallenges.herokuapp.com";//for postman test
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}
using CoreFramework.NUnitTestSetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.ProjectTestSetup
{
    public class ProjectTestSetUp : NUnitTestSetUp
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://www.youtube.com/";
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;


namespace CoreFramework.Reporter
{
    internal class HtmlReport
    {
        private static ExtentReports _report;
        private static ExtentTest extentTestSuite;
        private static ExtentTest extentTestCase;
        public static ExtentReports CreateReport()
        {     
            if (_report == null)
            {
                _report = CreateInstance();
            }
            return _report;
        }


        //Create a report folder
        public static ExtentReports CreateInstance()
        {          
            HtmlReportDirectory.InitReportDirection(); 
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter
                (HtmlReportDirectory.REPORT_FILE_PATH);
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.
                Configuration.Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";
      
            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;
        }

        public static void Flush()
        {
            if (_report != null)
            {
                _report.Flush();
            }
        }

        public static ExtentTest CreateTest(string className, string classDescription = "")
        {
           if (_report == null)
            {
                _report = CreateInstance();
            }
            extentTestSuite = _report.CreateTest(className, classDescription);
            return extentTestSuite;
        }

        public static ExtentTest CreateNode(string className, string testcase,
            string description = "")
        {          
            if (extentTestSuite == null)
            {
                extentTestSuite = CreateTest(className);
            }
            extentTestCase = extentTestSuite.CreateNode(testcase, description);
            return extentTestCase;
        }

        public static ExtentTest GetParent()
        {
            return extentTestSuite;
        }

        public static ExtentTest GetNode()
        {
            return extentTestCase;
        }

        public static ExtentTest GetTest()
        {
            if (GetNode() == null)
            {
                return GetParent();
            }
            return GetNode();
        }

        public static void Pass(string des)
        {          
            GetTest().Pass(des);
            TestContext.WriteLine(des);          
        }

        public static void Pass(string des, string path)
        {          
            GetTest().Pass(des).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);           
        }

        public static void Fail(string des)
        {         
            GetTest().Fail(des);
            TestContext.WriteLine(des);
        }

        public static void Fail(string des, string path)
        {          
            GetTest().Fail(des).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }

        public static void Fail(string des, string ex, string path)
        {
            //Add failed example and path to screenshot
            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }

        public static void Warning(string des)
        {
            GetTest().Warning(des);
            TestContext.WriteLine(des);
        }
        public static void Skip(string des)
        {
            GetTest().Skip(des);
            TestContext.WriteLine(des);
        }
     
        public static void MarkupPassJson(string json)
        {
            GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
        }

        public static void MarkupTable(string[][] someInts)
        {
            GetTest().Info(MarkupHelper.CreateTable(someInts));
        }

    
        public static void MarkupPassLabel(string text)
        {
            GetTest().Pass(MarkupHelper.CreateLabel(text, ExtentColor.Green));
        }

        public static void MarkupFailLabel(string text)
        {
            GetTest().Fail(MarkupHelper.CreateLabel(text, ExtentColor.Red));
        }

        public static void MarkupWarningLabel(string text)
        {
            GetTest().Warning(MarkupHelper.CreateLabel(text, ExtentColor.Orange));
        }

        public static void MarkupSkipLabel(string text)
        {
            GetTest().Skip(MarkupHelper.CreateLabel(text, ExtentColor.Blue));
        }

        public static void MarkupXML(string code)
        {
            GetTest().Info(MarkupHelper.CreateCodeBlock(code, CodeLanguage.Xml));
        }
    }
}

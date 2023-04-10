using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ABSATask2WebTable
{
    public class ExtentReporting
    {
        string workingDirectory = Environment.CurrentDirectory;
        ExtentReports extentReport = null;
        ExtentTest Logtest = null;

        //[OneTimeSetUp]
        public ExtentReports ExtentReportStart()
        {
            extentReport = new ExtentReports();
            //var htmlReporter = new ExtentHtmlReporter(workingDirectory + "ExtentReports"+ @"\" + "execution.html");
            var htmlReporter = new ExtentHtmlReporter(@" C: \\Users\\user\\Documents\\Java\\ABSATask2WebTables\\ABSATask2WebTable\\ABSATask2WebTable\\ExtentReports\execution.html");
            extentReport.AttachReporter(htmlReporter);
            return extentReport;
        }

      // [OneTimeTearDown]
        public void ExtentReportClose()
        {
            extentReport.Flush();
        }

        //[Test]
        //public void LogTest()
        public void LogTest(string sStatus)
        {
            extentReport = new ExtentReports();
            ExtentTest extentReportTest = null;
            extentReportTest = extentReport.CreateTest("Log Test").Info("Test Started");
            extentReportTest.Log(Status.Info,sStatus);
        }

    }
}

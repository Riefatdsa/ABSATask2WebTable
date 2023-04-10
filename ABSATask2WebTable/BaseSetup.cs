using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using System.IO;
using OpenQA.Selenium.Chrome;
using System.Threading;
using SeleniumExtras.PageObjects;
using SharpCompress.Common;
using NPOI.SS.Formula.Functions;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using System.Net.NetworkInformation;

namespace ABSATask2WebTable
{
    class BaseSetup
    {
        static ExtentReports extentReport = null;
        ExtentTest Logtest = null;
        static void Main(string[] args)
        {   
            GlobalTestClass();
        }

       // [OneTimeSetUp]
        public static ExtentReports ExtentReportStart()
        {
            extentReport = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(Environment.CurrentDirectory + @"\" + "ExtentReports" + @"\" + "execution.html");
            extentReport.AttachReporter(htmlReporter);
            return extentReport;
        }

       // [OneTimeTearDown]
        public static void ExtentReportClose()
        {
            extentReport.Flush();
        }

        public static void GlobalTestClass()
        {
            string[] webFlows = new string[] { "Click Element", "Input Text", "Navigate", "Validate", "Select" };
            string workingDirectory = Environment.CurrentDirectory;
            IWebDriver driver = new ChromeDriver(workingDirectory);

            using (var reader = new StreamReader(workingDirectory + @"\" + "Resources" + @"\" + "ABSATask2WebTableList.csv"))
            {
                var data = new List<List<string>>();
                extentReport = new ExtentReports();
                ExtentTest extentReportTest = null;
                extentReport = ExtentReportStart();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    //read these values from the CSV provided, the email and mobile will not be used but still added to list
                    data.Add(new List<String> { values[0], values[1], values[2], values[3], values[4], values[5], values[6] });
                }

                try
                { 
                    string temp = null;
                    //Navigate to url
                    temp = WebFlowExecution.webStepExecutor(webFlows[2], driver);
                    temp = WebFlowExecution.webStepExecutor(webFlows[3], driver);

                    if (temp.Equals("validated"))
                    {
                       extentReportTest = extentReport.CreateTest("Log Test").Info("Browser Started");
                       extentReportTest.Log(Status.Pass, "Title Validated - Passed");
                    }

                    ControlsFactory ControlLocator = new ControlsFactory();
                    PageFactory.InitElements(driver, ControlLocator);

                    //use the generator for User(*) and MobileSA Number
                    FakeDataGenerator getData = new FakeDataGenerator();
                    string uniqueUName = "";

                    for (int i = 0; i < data.Count; i++)
                    {
                        WebFlowExecution.webStepExecutor(webFlows[0], ControlLocator.AddUserButton, ""); //, filePath);
                        extentReportTest.Log(Status.Pass, "Load Add User Modal " + i + " - Passed");
                        WebFlowExecution.webStepExecutor(webFlows[1], ControlLocator.FirstName, data[i][0]);
                        extentReportTest.Log(Status.Pass, "Enter FirstName " + i + " - Passed");
                        WebFlowExecution.webStepExecutor(webFlows[1], ControlLocator.LastName, data[i][1]);
                        extentReportTest.Log(Status.Pass, "Enter LastName " + i + " - Passed");
                        uniqueUName = getData.GetUniqueUserName();
                        WebFlowExecution.webStepExecutor(webFlows[1], ControlLocator.UserName, uniqueUName);
                        extentReportTest.Log(Status.Pass, "Enter UserName " + i + " - Passed");
                        WebFlowExecution.webStepExecutor(webFlows[1], ControlLocator.Password, data[i][3]);
                        WebFlowExecution.webStepExecutor(webFlows[4], ControlLocator.CompanyOption, "");
                        extentReportTest.Log(Status.Pass, "Select Company " + i + " - Passed");
                        WebFlowExecution.webStepExecutor(webFlows[4], ControlLocator.RoleName, data[i][4]);
                        extentReportTest.Log(Status.Pass, "Select RoleName " + i + " - Passed");
                        WebFlowExecution.webStepExecutor(webFlows[1], ControlLocator.EmailAddress, data[i][5]);
                        extentReportTest.Log(Status.Pass, "Enter EmailAddress " + i + " - Passed");
                        WebFlowExecution.webStepExecutor(webFlows[1], ControlLocator.MobilePhone, data[i][6]);
                        extentReportTest.Log(Status.Pass, "Enter MobilePhone " + i + " - Passed");
                        WebFlowExecution.webStepExecutor(webFlows[0], ControlLocator.SaveButton, "");
                        extentReportTest.Log(Status.Pass, "User Saved " + i + " - Passed");
                    }
                    Thread.Sleep(3000);
                }
                catch (Exception e)
                {
                    Console.Write("An error occured" + e);
                }
            }
            ExtentReportClose();
            driver.Close();
            driver.Quit();
        }
    }
}

using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
/* Author: Riefat Dollie
 * Module: Web Flow Execution Steps
 * Descr: This module is instructed to call the relevant steps in the sequence provided by the dataset/array
 * Date:  05/04/2023
 *  */

namespace ABSATask2WebTable
{
    class WebFlowExecution
    {
        static ExtentReporting extentReportLog = new ExtentReporting();
        public static void webStepExecutor(string sAction, IWebElement sLocator, string sInput) 

        {
            switch (sAction)
            {
                case "Click Element":
                    //Add button click
                    sLocator.Click();
                    break;
                case "Input Text":
                    //Insert field value
                    sLocator.Clear();
                    sLocator.SendKeys(sInput);
                    Thread.Sleep(3000);
                    break;
                case "Select":
                    sLocator.SendKeys(sInput);
                    Thread.Sleep(3000);
                    break;
            }
        }

        //Overloaded
        public static String webStepExecutor(string sAction, IWebDriver idriver) 
        {
            string returnText = null;
           
            switch (sAction)
            {
                case "Navigate":
                    idriver.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");
                    Thread.Sleep(10);
                    idriver.Manage().Window.Maximize();
                    Thread.Sleep(10);
                   break;
                case "Validate":
                    string title = idriver.Title;
                    string expectedTitle = "Protractor practice website - WebTables";
                    Assert.AreEqual(expectedTitle, idriver.Title);
                    returnText = "validated";
                    break;
            }
            return returnText;
        }

    }
}

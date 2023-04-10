using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Author: Riefat Dollie
 * Module: Page Factory in conjunction with the POM
 * Descr: This module stores the WebElement Identifiers for the respective controls
 * Date:  05/04/2023
 *  */

namespace ABSATask2WebTable
{
    class ControlsFactory
    {
        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn-link pull-right']")]
        public IWebElement AddUserButton { get; set; }

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Name, Using = "LastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='optionsRadios']")]
        public IWebElement CompanyOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='RoleId']")]
        public IWebElement RoleName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='Email']")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='Mobilephone']")]
        public IWebElement MobilePhone { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn-success']")]
        public IWebElement SaveButton { get; set; }
    }
}


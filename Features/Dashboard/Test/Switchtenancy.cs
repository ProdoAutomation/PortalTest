using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using PortalNunit.Features.Authentication.Pages;
using PortalNunit.Features.Dashboard.Pages;
using PortalNunit.utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalNunit.Features.Dashboard.Test
{
    internal class Switchtenancy : Baseclass
    {
        [Test, Sequential]
        public void SwitchTenant()
        {
            DashboardPage DP = new DashboardPage(getdriver());
            LoginPage LP = new LoginPage(getdriver());
            LP.getLoginCTA().Click();
            string URL = driver.Url;
            driver.Navigate().GoToUrl(URL);
            Console.WriteLine(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LP.getUsername().SendKeys(getDataParser().extractData("username1"));
            test.Log(Status.Pass, "Entered Username");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LP.getPassword().SendKeys(getDataParser().extractData("password"));
            test.Log(Status.Pass, "Entered Password");
            LP.getSubmit().Click();
            test.Log(Status.Pass, "Submitted the Login details");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(LP.getModalClose())).Click();
            test.Log(Status.Pass, "Closed Modal Popup");
            string dashTitle = getdriver().Url;
            if (dashTitle == ConfigurationManager.AppSettings["DashURL"])
            {

            }
        }
        
}

    
}

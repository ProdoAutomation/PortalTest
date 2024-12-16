using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PortalNunit.Features.Authentication.Pages;
using PortalNunit.utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalNunit.Features.Authentication.Test
{
    
    public class Login : Baseclass
    {
        
        [Test,Sequential]
       
        public void Loginwithcrd()
        {
            LoginPage LP = new LoginPage(getdriver());
            LP.getLoginCTA().Click();
            extent.AddSystemInfo("Login page", "Login CTA clicked");
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
            test.Log(Status.Pass, "Modal popup clicked");
        }

        [Test, Sequential]
        public void Loginwithoutcrd()
        {
            LoginPage LP = new LoginPage(getdriver());
            LP.getLoginCTA().Click();
            string URL = driver.Url;
            driver.Navigate().GoToUrl(URL);
            Console.WriteLine(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LP.getUsername().SendKeys(getDataParser().extractData("username_wrong"));
            test.Log(Status.Pass, "Entered wrong Username");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LP.getPassword().SendKeys(getDataParser().extractData("password_wrong"));
            test.Log(Status.Pass, "Entered wrong Password");
            LP.getSubmit().Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var eror = LP.getValidationerror().Text;
            if(eror != null)
            {
               
                test.Log(Status.Pass,"'"+  eror+ "'"+"  error message is displayed");

            }

        }
    }
}

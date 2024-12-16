using AngleSharp.Dom;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PortalNunit.Features.Authentication.Pages;
using PortalNunit.Features.Dashboard.Pages;
using PortalNunit.utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace PortalNunit.Features.Dashboard.Test
{
    internal class Dashboard : Baseclass
    {
        [Test,Sequential]
        public void Dashboarditems()
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
                test.Log(Status.Pass,  " User successfully logged in and in dashboard page  " + dashTitle);
                IList<IWebElement> gridItems = DP.getGridLinks();
                int Count = gridItems.Count();
                test.Log(Status.Pass, Count + " links are displayed");
                Assert.IsNotEmpty(gridItems);
                foreach (IWebElement gridItem in gridItems)
                {
                    if (gridItem.Displayed)
                    {
                        string Attrib = gridItem.GetAttribute("title");
                        test.Log(Status.Pass, Attrib + " link is displayed");
                        
                    }
                }
                IList<IWebElement> gridLargerItems = DP.getGridLargerLinks();
                int CountLarger = gridItems.Count();
                test.Log(Status.Pass, CountLarger + " Larger links are displayed");
                Assert.IsNotEmpty(gridLargerItems);
                foreach (IWebElement gridLargeItem in gridLargerItems)
                {
                    if (gridLargeItem.Displayed)
                    {
                        string Attribitems = gridLargeItem.Text;
                        test.Log(Status.Pass, Attribitems + " link is displayed");

                    }
                }

            }

        }


        [Test,Sequential]
        public void NavigationiMenu()
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
                IList<IWebElement> menuItems = DP.getMenuNavigation();
                int CountMenu = menuItems.Count();
                test.Log(Status.Pass, CountMenu+ " menu links are displayed");
                Assert.IsNotEmpty(menuItems);
                foreach (IWebElement menuItem in menuItems)
                {
                    if (menuItem.Displayed)
                    {
                        string Attribitems = menuItem.Text;
                        test.Log(Status.Pass, Attribitems + " link is displayed");
                        
                        
                        
                    }
                }
                IList<IWebElement> menuIcons = DP.getMenuIcons();
                int CountIcons = menuItems.Count();
                test.Log(Status.Pass, CountIcons + " Icons  are displayed");
                Assert.IsNotEmpty(menuIcons);
                foreach (IWebElement menuIcon in menuIcons)
                {
                    string Icons = menuIcon.GetAttribute("class");
                    Assert.IsNotEmpty(Icons);
                    test.Log(Status.Pass, Icons + " Icon is displayed");
                }
              
                foreach (IWebElement menuIconlink in menuItems)
                {
                    string Attribitecdms = menuIconlink.Text;
                   
                    if (Attribitecdms == "Account")
                    {
                        menuIconlink.Click();
                        string pageTitle = getdriver().Url;
                        if (pageTitle == ConfigurationManager.AppSettings["AccURL"])
                        {

                            test.Log(Status.Pass, ConfigurationManager.AppSettings["AccURL"] + " menu is clicked");
                            break;
                        }
                    }
                }
                

            }
        }
    }
}

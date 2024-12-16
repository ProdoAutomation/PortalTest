using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace PortalNunit.utilities
{
    public class Baseclass 
    {
       public IWebDriver driver;
        [SetUp]
        public void Startbrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            var SiteURL = ConfigurationManager.AppSettings["url"];
            driver.Navigate().GoToUrl("https://portaldemo.prodo.com/");
        }

        public IWebDriver getdriver()
        {
            return driver;
        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        [TearDown]
        public void Aftertest()
        {
            driver.Dispose();
        }

    }
}

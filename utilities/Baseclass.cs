using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V129.Page;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;


namespace PortalNunit.utilities
{
    public class Baseclass 
    {
         public IWebDriver driver;
        //  public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public static ExtentReports extent=  new ExtentReports();
        public static ExtentTest test;
        [OneTimeSetUp]
        public void Setup()
        {
                string workingdirectory = Environment.CurrentDirectory;
                string parentdirectory = Directory.GetParent(workingdirectory).Parent.Parent.FullName;
                string reportpath = parentdirectory + "//index.html";
                var report = new ExtentSparkReporter(reportpath);
                extent.AttachReporter(report);
                extent.AddSystemInfo("Env", "Prodo Portal site");
        }

        [SetUp]
        public void Startbrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            String SiteURL = ConfigurationManager.AppSettings["url"];
            driver.Navigate().GoToUrl(SiteURL);
            test.Log(Status.Pass, "Site Launched");
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
           var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            if (status == TestStatus.Failed)
            {
                DateTime time = DateTime.Now;
             String fileName=  "Screenshot_"+ time.ToString("g") + ".png";
                test.Fail("Test Failed", screenresponse(driver, fileName));
                test.Log(Status.Fail, "Test failed with logtrace" + stacktrace);
                
            }
            else if(status == TestStatus.Passed){
                TestContext.WriteLine("Test is Passed");
            }
            extent.Flush();
            driver.Dispose();
        }


        //Capture screenshot
        
        public Media screenresponse(IWebDriver driver,String ScreenName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
          var screenshot =  ts.GetScreenshot().AsBase64EncodedString;
           
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScreenName).Build();
            }

    }
}

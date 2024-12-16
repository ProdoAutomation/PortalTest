using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalNunit.Features.Authentication.Pages
{
    internal class Register
    {
        IWebDriver driver;

        //Username
        [FindsBy(How = How.XPath, Using = "//*[@id='createAccount']")]
        private IWebElement sigup;
        public Register(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}

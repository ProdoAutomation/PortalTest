using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalNunit.Features.Authentication.Pages
{
    public class LoginPage
    {
        IWebDriver driver;
       
        //Username
        [FindsBy(How = How.Id, Using = "signInName")]
        private IWebElement username;

        //Password
        [FindsBy(How = How.XPath, Using = "//*[@id='password']")]
        private IWebElement password;

        //Submit
        [FindsBy(How = How.XPath, Using = "//*[@id='next']")]
        private IWebElement submit;

        
        //LoginCTA
        [FindsBy(How = How.XPath, Using = "//*[@class='e-btn e-btn--primary e-btn--wide e-btn--loader e-btn--inline m-access_form__btn']")]
        private IWebElement LoginCTA;

        //Validation error 
        [FindsBy(How = How.XPath, Using = "//*[@class='error pageLevel']/p")]
        private IWebElement Validationerror;

        //Modalclose
        [FindsBy(How = How.XPath, Using = "//*[@class='m-modal__close ti-x js-onboarding-tour-close']")]
        private IWebElement modalClose;


        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }



        public IWebElement getUsername()
        {
            return username;
        }

        public IWebElement getPassword()
        {
            return password;
        }

        public IWebElement getLoginCTA()
        {
            return LoginCTA;
        }
        public IWebElement getSubmit()
        {
            return submit;
        }

        public IWebElement getModalClose()
        {
            return modalClose;
        }

        public IWebElement getValidationerror()
        {
            return Validationerror;
        }

    }



}

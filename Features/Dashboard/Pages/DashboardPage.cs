using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalNunit.Features.Dashboard.Pages
{
    internal class DashboardPage
    {
        IWebDriver driver;

        //Dashboard
        [FindsBy(How = How.XPath, Using = "//*[@class='m-dashboard_grid__content m-dashboard_grid__content--link']")]
        private IList<IWebElement> gridLinks;


        //Dashboard larger links
        [FindsBy(How = How.XPath, Using = "//*[@class='m-dashboard_grid__content m-dashboard_grid__content--large']/h3")]
        private IList<IWebElement> gridLargerLinks;

        //Menu Navigations
        [FindsBy(How = How.XPath, Using = "//*[@class='m-navigation__list']/li/a")]
        private IList<IWebElement> menuNavigation;

        
        //Menu Navigations Icons
        [FindsBy(How = How.XPath, Using = "//*[@class='m-navigation__list']/li/a/i")]
        private IList<IWebElement> menuIcons;

        //TenancyCTA
        [FindsBy(How = How.XPath, Using = "//*[@class='m-toolbox__list']/li/a")]
        private IList<IWebElement> tenancyCTA;

        
        //Tenancy Modal
        [FindsBy(How = How.XPath, Using = "//*[@class='m-modal__intro']/h4")]
        private IList<IWebElement> tenancyModal;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IList<IWebElement> getGridLinks()
        {
            return gridLinks;
        }

        public IList<IWebElement> getGridLargerLinks()
        {
            return gridLargerLinks;
        }

        public IList<IWebElement> getMenuNavigation()
        {
            return menuNavigation;
        }

        public IList<IWebElement> getMenuIcons()
        {
            return menuIcons;
        }

        public IList<IWebElement> getTenancyCTA()
        {
            return tenancyCTA;
        }

        public IList<IWebElement> getTenancyModal()
        {
            return tenancyModal;
        }


    }
}

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.pageObjects
{
    internal class CreateAccountPage
    {
        IWebDriver driver;
        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='tblcrtac']/tbody/tr[3]/td[3]/input")]
        public IWebElement? FullNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'login')]")]
        public IWebElement? EmailText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'avail')]")]
        public IWebElement? CheckAvailabilityButton { get; set; }

        [FindsBy(How = How.Id, Using = "Register")]
        public IWebElement? CreateMyAccountButton { get; set; }

        public void FullNameInput(string name)
        {
            FullNameText?.SendKeys(name);
        }

        public void EmailInput(string email)
        {
            EmailText?.SendKeys(email);
        }

        public void ClickOnCheckAvailabilityButton()
        {
            CheckAvailabilityButton?.Click();
        }

        public void ClickOnCreateAccountButton()
        {
            CreateMyAccountButton?.Click();
        }

        public void FullNameClear( )
        {
            FullNameText?.Clear();
        }

        public void EmailInputClear()
        {
            EmailText?.Clear();
        }
    }
}

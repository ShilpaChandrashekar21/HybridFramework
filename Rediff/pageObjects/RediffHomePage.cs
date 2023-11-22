using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.pageObjects
{
    internal class RediffHomePage
    {
        IWebDriver driver;
        public RediffHomePage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.LinkText, Using = "Create Account")]
        public IWebElement? CreateAccountLink {  get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign in")]
        public IWebElement? SignInLink { get; set; }

        //Act

        public void ClickOnCreateAccountLink()
        {
            CreateAccountLink?.Click();
        }

        public void ClickOnSignInLink()
        {
            SignInLink?.Click();
        }

        public CreateAccountPage ClickOnCreateAccount()
        {
            CreateAccountLink?.Click();
            return new CreateAccountPage(driver);
        }

        public SignInPage ClickOnSignIn()
        {
            SignInLink?.Click();
            return new SignInPage(driver);
        }
    }
}

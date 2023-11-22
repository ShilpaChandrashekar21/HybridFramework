using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.pageObjects
{
    internal class SignInPage
    {
        IWebDriver driver;
        public SignInPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            
        }

        [FindsBy(How = How.Id, Using = "login1")]
        public IWebElement? UserNameText {  get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement? UserPasswordText { get; set; }


        [FindsBy(How = How.Id, Using = "remember")]
        public IWebElement? RememberMeCheckBox { get; set; }

        [FindsBy(How = How.Name, Using = "proceed")]
         public IWebElement? SignInButton { get; set; }

        public void UserNameInput(string name)
        {
            UserNameText?.SendKeys(name);
        }

        public void UserPasswordInput(string password)
        {
            UserPasswordText?.SendKeys(password);
        }

        public void ClickOnRememberMeCheckBox()
        {
            RememberMeCheckBox?.Click();
        }

        public void ClickOnSignInButton()
        {
            SignInButton?.Click();
        }
    }
}

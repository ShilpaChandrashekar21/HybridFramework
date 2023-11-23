using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.pageObjects
{
    internal class BunnyCartHomePage
    {
        IWebDriver driver;
        public BunnyCartHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        //input[@id='search']
        [FindsBy(How = How.Id, Using ="search")]
        [CacheLookup]
        private IWebElement? SearchBar { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "customer-register-link")]
        [CacheLookup]
        private IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement? FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastName { get; set; }

        [FindsBy(How = How.Id, Using = "popup-email_address")]
        private IWebElement? EmailId { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? Password { get; set; }

        [FindsBy(How = How.Id, Using = "password-confirmation")]
        private IWebElement? ConfirmPassword { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? PhoneNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]
        private IWebElement? CreateAnAccountButton { get; set; }

        public void ClickOnCreateAccountLink()
        {
            CreateAccountLink?.Click();
        }
       
        public void CreateAccountLinkInput(string fname,string lname,string 
            email,string pwd,string cpwd,string phnum)
        {
            

            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(10);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);

            IWebElement modal = fwait.Until(d => d.FindElement
            (By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));

            FirstName?.SendKeys(fname);
            LastName?.SendKeys(lname);
            EmailId?.SendKeys(email);

            ScrollIntoView(driver, Password);
            Password?.SendKeys(pwd);
            ConfirmPassword?.SendKeys(cpwd);

            ScrollIntoView(driver, PhoneNumber);
            PhoneNumber?.SendKeys(phnum);

            CreateAnAccountButton?.Click();


        }

        static void ScrollIntoView(IWebDriver driver,IWebElement element)
        {
            IJavaScriptExecutor js =(IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public SearchResultPage SearchBarInput(string product)
        {
            if(SearchBar == null)
            {
                throw new NoSuchElementException();
            }
            //SearchBar?.Click();
            SearchBar?.SendKeys(product);
            SearchBar?.SendKeys(Keys.Enter);
            return new SearchResultPage(driver);
        }
    }
}

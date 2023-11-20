using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    [TestFixture]
    internal class LinkedInTests : CoreCodes
    {
        [Test]
        [Author("Shilpa","shilpachandrashekar@g.com")]
        [Description("Check for valid login")]
        [Category("Regression testing")]
        public void LoginTest()
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            /*IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            IWebElement password = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));*/
            
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            /*IWebElement emailInput = wait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement password = wait.Until(d => d.FindElement(By.Id("session_password")));*/

            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);//fwait.Message = "No such element"
            
            IWebElement emailInput = fwait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement password = fwait.Until(d => d.FindElement(By.Id("session_password")));
            
            emailInput.SendKeys("Shilpa C");
            password.SendKeys("Password");
            
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        /*[Test, Author("Shilpa", "shilpachandrashekar@g.com")]
        [Description("Check for invalid login")]
        [Category("Smoke testing")]
        public void LoginTestWithInvalidCredentials()
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);//fwait.Message = "No such element"

            IWebElement emailInput = fwait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement password = fwait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys("qre123@gi.com");
            password.SendKeys("Password");
            Thread.Sleep(1000);
            ClearForm(emailInput);
            ClearForm(password);

            emailInput.SendKeys("123@gi.com");
            password.SendKeys("12345");
            Thread.Sleep(1000);
            ClearForm(emailInput);
            ClearForm(password);

            emailInput.SendKeys("qr123@gi.com");
            password.SendKeys("Password");
            Thread.Sleep(1000);
            ClearForm(emailInput);
            ClearForm(password);
        }*/

        public void ClearForm(IWebElement element)
        {
            element.Clear();
        }
        /*
                [Test,Author("CCC", "ccc@g.com")]
                [Description("Check for invalid login"),Category("Regression testing")]
                [TestCase("qre123@gi.com", "Password")]
                [TestCase("jkl123@gi.com", "90875")]
                [TestCase("qre123@ju.com", "56789")]
                public void LoginTestWithInvalidCredentials(string email, string pass)
                {
                    DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
                    fwait.Timeout = TimeSpan.FromSeconds(5);
                    fwait.PollingInterval = TimeSpan.FromMicroseconds(100);
                    fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                    Console.WriteLine(fwait.Message);//fwait.Message = "No such element"

                    IWebElement emailInput = fwait.Until(d => d.FindElement(By.Id("session_key")));
                    IWebElement password = fwait.Until(d => d.FindElement(By.Id("session_password")));

                    emailInput.SendKeys(email);
                    password.SendKeys(pass);
                    ClearForm(emailInput);
                    ClearForm(password);
                    Thread.Sleep(2000);
                }*/


        [Test, Author("CCC", "ccc@g.com")]
        [Description("Check for invalid login"), Category("Regression testing")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void LoginTestWithInvalidCredentials(string email, string pass)
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);//fwait.Message = "No such element"

            IWebElement emailInput = fwait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement password = fwait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            password.SendKeys(pass);
            ClearForm(emailInput);
            ClearForm(password);
            Thread.Sleep(2000);
        }

        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] {"qre123@gi.com", "Password"},
                new object[] {"jkl123@gi.com", "90875" },
                new object[] {"qre123@ju.com", "56789" }
            };
        }
        
    }
}

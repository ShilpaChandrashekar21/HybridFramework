using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    [TestFixture]
    internal class ActionsEvent : CoreCodes
    {
        [Test]
        public void ActionsTest() 
        {
            IWebElement homeLink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdHomeLink = driver.FindElement(By.XPath
                ("/html/body/div/table/tbody/tr/td/table/tbody/tr/td" +
                "/table/tbody/tr/td/table/tbody/tr"));
           
            Actions actions = new Actions(driver);
            Action mouseHover = () => actions
               .MoveToElement(homeLink)
               .Build()
               .Perform();
            Console.WriteLine("Before " + tdHomeLink.GetCssValue("background-color"));           
            mouseHover.Invoke();
            
            Console.WriteLine("After " + tdHomeLink.GetCssValue("background-color"));

        }

        [Test] 
        public void MultipleActionsTest() 
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);
            IWebElement emailInput = fwait.Until(d => d.FindElement(By.Id("session_key")));
            
            Actions actions = new Actions(driver);
            Action shiftHold = () => actions.KeyDown(Keys.Shift)
            .SendKeys(emailInput,"abc")
            .KeyUp(Keys.Shift)
            .Build()
            .Perform();

            shiftHold.Invoke();
            Console.WriteLine("Text "+emailInput.GetAttribute("value"));
            Thread.Sleep(4000);
        }

    }
}

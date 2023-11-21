using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNUnit
{
    [TestFixture]
    internal class Naaptol : BaseCodes
    {

        
        [Test]
        [Order(1)]
        public void SearchProductTest()
        {
            driver.Navigate().GoToUrl("https://www.naaptol.com/");

            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(10);
            fwait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);

            IWebElement search = fwait.Until(d => d.FindElement(By.Id("header_search_text")));
            search.Click();
            search.SendKeys("eyewear");
            search.SendKeys(Keys.Enter);

            Assert.That(driver.Url.Contains("eyewear"));
            Console.WriteLine("SearchProductTest: " + "Passed");
        }

        [Test]
        [Order(2)]
        [TestCase("5")]
        
        public void SelectProductTest(string numOf)
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(10);
            fwait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);

            IWebElement select = driver.FindElement(By.Id("productItem" + numOf));
            select.Click();

            List<string> lstWindow = driver.WindowHandles.ToList();

            foreach (var i in lstWindow)
            {
                Console.WriteLine("Switching to window: " + i);
                driver.SwitchTo().Window(i);
            }
            Assert.That(driver.Url.Contains("reading"));
            Console.WriteLine("SelectProductTest: Passed");

        }

        [Test]
        [Order(3)]
        public void AddProductTest()
        {
            
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(10);
            fwait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);

            IWebElement selectSize = fwait.Until(d => d.FindElement(By.LinkText("Black-2.50")));
            selectSize.Click();

            IWebElement addProduct = fwait.Until(d => d.FindElement(By.Id("cart-panel-button-0")));
            addProduct.Click();
            Assert.That(driver.Url.Contains("reading"));
            Console.WriteLine("AddProductTest: Passed");



        }


        [Test]
        [Order(4)]
        public void CartTest()
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(10);
            fwait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);

            Thread.Sleep(1000);
            IWebElement cart = fwait.Until(d=>d.FindElement(By.XPath("//h1[text()='My Shopping Cart: ']")));
            IWebElement productAvail = fwait.Until(d => d.FindElement(By.XPath("//a[text()='Reading Glasses with LED Lights (LRG4)']")));

            IWebElement popUpClose = fwait.Until(d => d.FindElement(By.XPath("//a[@title='Close']")));
            popUpClose.Click();
            Assert.That(driver.Url.Contains("reading"));
            Console.WriteLine("cartTest: Passed");

        }

            

            

            

        
    }
}

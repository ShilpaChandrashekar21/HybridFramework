using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExamples
{
    internal class AmazonTests
    {
        IWebDriver? driver;

        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver(); //opens browser
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();

        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //opens browser
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();

        }

        public void TitleTest()
        {
            Thread.Sleep(1000); //should never use thread.sleep in code
            string title = driver.Title;
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", title);
            Console.WriteLine("Title test - Passed");
        }

        public void LogoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Logo Click test - Passed");
        }

        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(driver.Title.Equals("Amazon.com : mobiles") 
                && (driver.Url.Contains("mobiles")));
            Console.WriteLine("Search Product test - Passed");
        }

        public void ReloadHomePage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            Thread.Sleep(3000);
        }

        public void TodaysDealTest()
        {
           IWebElement todaysDeal= driver.FindElement(By.LinkText("Today's Deals"));
            if(todaysDeal == null)
            {
                throw new NoSuchElementException("Todays Deals link not present");
            }
            
                todaysDeal.Click();
            Assert.That(driver.FindElement(By.TagName("h1")).Text
                .Equals("Today's Deals"));
                Console.WriteLine("Todays deal test - Passed");
            
        }

        public void SignInAccountListTest()
        {
            IWebElement hellosignin=driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if(hellosignin == null)
            {
                throw new NoSuchElementException("No hello, signin");
            }
            IWebElement accountAndList = driver.FindElement(By.XPath("//*[@id='nav-link-accountList']/span"));
            if(accountAndList == null)
            {
                throw new NoSuchElementException("No Account and List");
            }
           
            /*Assert.That( hellosignin.Text.Equals("Hello, sign in") &&
                accountAndList.Text.Equals("Account & Lists"));*/

            Assert.That(hellosignin.Text.Equals("Hello, sign in"));
            Console.WriteLine("hello,SignIn test - " +
                "passed");
            Thread.Sleep(3000);
            Assert.That(accountAndList.Text.Equals("Account & Lists"));
            Console.WriteLine("Account and List test - " +
                "passed");
            
        }

        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            IWebElement motorolaCheckBox = driver.
                FindElement(By.XPath("//*[@id='p_89/Motorola']/span/a/div/label/i"));
            Thread.Sleep(3000);
            motorolaCheckBox.Click();
            Thread.Sleep(5000);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Motorola is selected");
            //---------------------------------------------------
            Thread.Sleep(3000);
            driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            IWebElement xiaomiCheckBox = driver.FindElement
                (By.XPath("//*[@id=\'p_89/Xiaomi\']/span/a/div"));
            xiaomiCheckBox.Click();
            Thread.Sleep(5000);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Xiaomi\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Xiaomi is selected");
        }

        public  void SortBySelectTest()
        {
           IWebElement sortby= driver.FindElement(By.XPath("//*[contains(@class,'a-native-dropdown a-declarative')]"));
            SelectElement select = (SelectElement)sortby;
            select.SelectByValue("1");
            Thread.Sleep(2000);
            Console.WriteLine(select.SelectedOption);
        }

        public void End()
        {
            driver.Close();

        }

    }
}

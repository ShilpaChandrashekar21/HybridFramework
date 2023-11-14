using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class NavigationTest
    {
        IWebDriver driver; //creating driver instance

        public void Initialize()
        {
            driver = new ChromeDriver(); // opens the browser
            driver.Url = "https://www.google.com"; // navigating to the url of the webpage
            driver.Manage().Window.Maximize();// to maximize the screen
        }
        public void NavigatingToTest()
        {
            
            
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.yahoo.com/");//navigating to yahoo webpage
            Thread.Sleep(1000);
            driver.Navigate().Back();//going back to previous web page
            Thread.Sleep(1000);
            driver.Navigate().Forward();//moving it to next web page 
            Thread.Sleep(1000);
            driver.Navigate().Back();
            IWebElement searchinputbox = driver.FindElement(By.Id("APjFqb"));//finding the element of search box
            searchinputbox.SendKeys("What's new for Diwali 2023");// entering the value to be searched
            Thread.Sleep(2000);
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));//finding the search button
            gsbutton.Click();
            Thread.Sleep(1000);
            Assert.That(driver.Title.Contains("What's new for Diwali 2023"));//checking if the title is equal to the given value
            Console.WriteLine("NavigatingToTest - Passed");
            driver.Navigate().Refresh();// refreshing the current webpage


        }

        public void Destruct()
        {
            driver.Close();
        }
    }
}

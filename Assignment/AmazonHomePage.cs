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
    internal class AmazonHomePage
    {
        IWebDriver driver;

        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Url= "https://www.amazon.com";
            driver.Manage().Window.Maximize();
        }

        public void CheckTitle()
        {
            Assert.That("Amazon".Equals(driver.Title));
            Console.WriteLine("Title test - Passed");
        }

    }
}

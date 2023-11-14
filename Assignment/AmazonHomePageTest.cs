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
    internal class AmazonHomePageTest
    {
        IWebDriver driver; //creating driver instance

        public void Initialize()
        {
            driver = new ChromeDriver(); // opens the browser
            driver.Url= "https://www.amazon.com"; // url of the webpage
            driver.Manage().Window.Maximize();// to maximize the screen
        }

        public void CheckTitleTest()
        {
            Thread.Sleep(1000);// making thread to sleep for a second
            Assert.That(driver.Title.Contains("Amazon"));// Checking for the title
            Console.WriteLine("Title test - Passed");
            
            
        }

        public void CheckOrganizationTypeTest()
        {
            Thread.Sleep(1000);
            
            Assert.That(driver.Url.Contains(".com"));
            Console.WriteLine("Check Organization Type Test - Passes");
        }

        

        public void Destruct()
        {
            driver.Close();// closes the current tab
        }

    }
}

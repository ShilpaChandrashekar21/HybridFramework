using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SeleniumExamples
{
    internal class Google_home_page_tests
    {
        IWebDriver? driver;

        public void InitializeEdgeDriver()
        {
             driver = new EdgeDriver(); //opens browser
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();

        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //opens browser
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();

        }

        public void TitleTest() 
        {
            Thread.Sleep(1000); //should never use thread.sleep in code
            string title = driver.Title;
            //Console.WriteLine("Title "+title);
            //Console.WriteLine("Title Length "+title.Length);
            Assert.AreEqual("Google", title);
            Console.WriteLine("Title test - Passed");
        }

        public void PageSourceTest()
        {
           //Console.WriteLine("Page source " + driver.PageSource);
           //Console.WriteLine("Page source Length test "+driver.PageSource.Length);
        }

        public void PageUrlTest()
        {
           /* Console.WriteLine("Url: "+driver.Url);
            Console.WriteLine("Url Length: "+driver.Url.Length);*/
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("Url test - Passed");
        }

        public void GoogleSearchTest()
        {
            IWebElement searchinputbox = driver.FindElement(By.Id("APjFqb"));
            searchinputbox.SendKeys("hp laptop");
            Thread.Sleep(2000);
            //IWebElement gsbutton = driver.FindElement(By.Name("btnK"));
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
            gsbutton.Click();
            Assert.AreEqual("hp laptop - Google Search",driver.Title);
            Console.WriteLine("Google search test - Passed");
        }

        public void GmailLinkTest()
        {
            /*IWebElement searchlink = driver.FindElement(By.LinkText("Gmail"));
            searchlink.Click();*/
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
            Thread.Sleep(2000);
            string title = driver.Title;
            //Assert.That(title.Contains("Gmail"));

            Assert.That(driver.Url.Contains("gmail"));

            Console.WriteLine("Gmail link test - Passed");
        }

        public void ImagesLinkTest()
        {
            driver.Navigate().Back();

            driver.FindElement(By.PartialLinkText("ge")).Click();
            Thread.Sleep(2000);
            string title = driver.Title;
           

            Assert.That(title.Contains("Images"));

            Console.WriteLine("Image link test - Passed");
        }

        public void LocalizationTest()
        {
            driver.Navigate().Back();
            string localLocation=driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(1000);
            Assert.AreEqual("India", localLocation);
            Console.WriteLine("Localization Test - Passed");
            
        }

        public void GoogleAppYouTubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//*[@id=\'yDmH0d']/c-wiz/div/div/c-wiz/div/div/div[2]/div[2]/div[1]/ul/li[4]/a/span"));
            driver.FindElement(By.CssSelector("//*[@class='LVal7b']/ul/li[4]/a/span[text()='YouTube']")).Click();
            Thread.Sleep(2000);
            Assert.That("YouTube".Equals( driver.Title));
        }


        public void End()
        {
            driver.Close();

        }


    }
}

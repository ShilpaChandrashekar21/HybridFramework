using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnitExamples
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
             driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
        }

        
        [Test] 
        public void CheckForTitle()
        {
            Thread.Sleep(10000);
            string title = driver.Title;
            //Assert.AreEqual("Google", title);
            Assert.That(title, Is.EqualTo("Google"));
        }

        [TearDown] 
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    [TestFixture] //acts as a independent test group,
                  //will contain more than one test case
    internal class GoogleHomePageTests : CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(10)]
        public void TitleTest()
        {
            Thread.Sleep(1000); //should never use thread.sleep in code
            string title = driver.Title;
            Assert.That(title, Is.EqualTo("Google"));
            Console.WriteLine("Title test - Passed");
        }
        [Ignore("other")]
        [Test]
        [Order(21)]
        public void GoogleSearchTest()
        {
            IWebElement searchinputbox = driver.FindElement(By.Id("APjFqb"));
            searchinputbox.SendKeys("hp laptop");
            Thread.Sleep(2000);
             IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
            gsbutton.Click();
            Assert.That(driver.Title, Is.EqualTo("hp laptop - Google Search"));
            Console.WriteLine("Google search test - Passed");
        }
        [Ignore("other")]
        [Test]
        public void AllLinkStatusTest()
        {
            List<IWebElement> allLinks = driver.
                FindElements(By.TagName("a")).ToList();

            foreach (var link in allLinks)
            {
                string url = link.GetAttribute("href");
                if (url == null)
                {
                    Console.WriteLine("Url is null");
                    continue;
                }
                else
                {
                    bool isWorking = CheckLinkStatus(url);
                    if (isWorking)
                    {
                        Console.WriteLine(url + " is working");
                    }
                    else
                    {
                        Console.WriteLine(url + " is not working");
                    }
                
                }
            }
        }
    }
}

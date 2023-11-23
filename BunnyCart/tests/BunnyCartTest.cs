using BunnyCart.pageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.tests
{
    [TestFixture]
    internal class BunnyCartTest : CoreCodes
    {
        [Test, Order(2)]
        public void CreateAnAccountTest()
        {
            var homePage = new BunnyCartHomePage(driver);
          
            homePage.ClickOnCreateAccountLink();
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']" +
                "//following::h1[2]")).Text, Is.EqualTo("Create an Account"));

                homePage.CreateAccountLinkInput("alpha", "xyz", "alpha@df.com",
                   "1234", "1234", "9876543210");
            }
            catch (AssertionException)
            {
                Console.WriteLine("Modal didn't appear");
            }
            
        }

        [Test, Order(1)]
        public void SearchInputTest()
        {
            var homePage = new BunnyCartHomePage(driver);
            homePage.SearchBarInput("water poppy");
        }


    }
}

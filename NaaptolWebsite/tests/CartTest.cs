using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaaptolWebite;
using NaaptolWebsite.pomObjects;

namespace NaaptolWebsite.tests
{
    //[TestFixture,Order(3)]
    internal class CartTest : CoreCodes
    {
        //[Test]
        public void ProductInCartTest()
        {
            var addProduct = new AddProductPage(driver);
            var cart = addProduct.AddSelectedProductLink();

            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(10);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);

            IWebElement cartPage = fwait.Until(d => d.FindElement(By.LinkText("Reading Glasses with LED Lights (LRG4)")));

            Console.WriteLine("Product: " + cart.GetProductInCart());
            Assert.That(cart.GetProductInCart().Contains("reading-glasses-with-led-lights-lrg4"));


            cart.ChangeProductQuantity();
            Console.WriteLine(cart.ProductQuantity.GetAttribute("value"));

            Assert.That(cart.ProductQuantity.GetAttribute("value").Equals("2"));

            cart.ClickOnRemoveProduct();

            IWebElement cartEmpty = fwait.Until(d => d.FindElement(By.XPath("//span[@class='font-bold'][text()='You have No Items in Cart !!! ']")));

            Console.WriteLine(cart.GetCartEmpty());
            try
            {
                Assert.That(cart.GetCartEmpty().Contains("No Items in Cart"));
                test = extent.CreateTest("Cart In Product Test - Pass");
                test.Pass("Cart In Product Test success");
            }
            catch
            {
                test = extent.CreateTest("Cart In Product Test - Fail");
                test.Fail("Cart In Product Test failed");
            }


            cart.ClickCloseCart();
        }
    }
}

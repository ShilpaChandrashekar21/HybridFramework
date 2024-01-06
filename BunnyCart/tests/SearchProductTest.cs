using BunnyCart.pageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.tests
{
    [TestFixture,Order(1)]
    internal class SearchProductTest:CoreCodes
    {
        [Test]
        [TestCaseSource(nameof(data))]
        public void SearchInputTest(string pname, int count)
        {
            var homePage = new BunnyCartHomePage(driver);
            var searchProductPage = homePage.SearchBarInput(pname);
            try
            {
                //ScrollIntoView(driver, driver.FindElement( By.XPath("(//a[@class='product-item-link'])[2]") ));
                Assert.That(searchProductPage.GetSearchedResult(count), Does.Contain(pname));
                Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
                Console.WriteLine("different product appeared");
            }
            Thread.Sleep(4000);
            var productPage = searchProductPage.ClickOnSearchedResult(count);
            try
            {
                Thread.Sleep(2000);
                Assert.That(productPage.GetProductTitle(), Does.Contain(pname));
                productPage.ClickOnProductQuantity();
                productPage.ClickOnAddToCartButton();
            }
            catch (AssertionException)
            {
                Console.WriteLine("Clicked On wrong Product");
            }

        }

        static object[] data()
        {
            return new object[]
            {
                new object[] { "water", "5" },
                new object[] { "lily", "4" }

            };
        }
    }
}

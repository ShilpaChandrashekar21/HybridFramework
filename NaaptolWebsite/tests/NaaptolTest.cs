using NaaptolWebite;
using NaaptolWebsite.pomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolWebsite.tests
{
    [TestFixture]
    internal class NaaptolTest : CoreCodes
    {
        [Test,Category("Regression testing")]
        public void SearchProductTest()
        {
            var naaptolHomePage = new NaaptolHomePage(driver);
            var selectProduct=  naaptolHomePage.SearchForProduct("eyewear");
            Assert.That(driver.Url.Contains("eyewear"));

            // = new Select5thProductPage(driver);
            var addProduct = selectProduct.SelectAProduct();
            

            List<string> lstWindow = driver.WindowHandles.ToList();

            foreach (var i in lstWindow)
            {
                Console.WriteLine("Switching to window: " + i);
                driver.SwitchTo().Window(i);
            }
            
            
            addProduct.SelectPowerLink();

            var cart = addProduct.AddSelectedProductLink();
            //Assert.Equals(cart.ProductInCart,"Reading Glasses with LED Lights (LRG4)");
            Thread.Sleep(3000);

            //new CartPage(driver);

            cart.ClickCloseCart();


        }

        

    }
}

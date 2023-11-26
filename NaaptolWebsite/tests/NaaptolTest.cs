using BunnyCart.utilities;
using NaaptolWebite;
using NaaptolWebsite.pomObjects;
using NaaptolWebsite.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolWebsite.tests
{
    [TestFixture,Order(1)]
    internal class NaaptolTest : CoreCodes
    {
        [Test]
        
        public void SearchProductTest()
        {
            var naaptolHomePage = new NaaptolHomePage(driver);

            //DDT
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/testExcelData/InputData.xlsx";
            string? sheetName = "NaaptolTestData";

            List<TestData> searchDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var searchData in searchDataList)
            {
                string? searchText = searchData.ProductName;

                var selectProduct = naaptolHomePage.SearchForProduct(searchText);
                try
                {
                    //Extent 
                    Assert.That(driver.Url.Contains(searchText));
                    test = extent.CreateTest("Naaptol Test - Pass");
                    test.Pass("SearchProductTest success");
                }
                catch
                {
                    test = extent.CreateTest("Naaptol Test - Fail");
                    test.Fail("SearchProductTest failed");
                }

                var addProduct = selectProduct.SelectAProduct();
                List<string> lstWindow = driver.WindowHandles.ToList();

                foreach (var i in lstWindow)
                {
                    Console.WriteLine("Switching to window: " + i);
                    driver.SwitchTo().Window(i);
                }

                try
                {
                    Assert.That(driver.Url.Contains("colored"));
                    test = extent.CreateTest("Select Product Test- Pass");
                    test.Pass("Select Product Test success");
                }
                catch
                {
                    test = extent.CreateTest("Select Product Test - Fail");
                    test.Fail("Select Product Test failed");
                }


                addProduct.SelectSizeLink();
                var cart = addProduct.AddSelectedProductLink();

                DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
                fwait.Timeout = TimeSpan.FromSeconds(10);
                fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                Console.WriteLine(fwait.Message);

                IWebElement cartPage = fwait.Until(d => d.FindElement(By.LinkText("Colored Daily Use Reading Glasses (BRG9)")));

                Console.WriteLine("Product: " + cart.GetProductInCart());
                Assert.That(cart.GetProductInCart().Contains("colored-daily-use-reading-glasses"));


                cart.ChangeProductQuantity();
                Console.WriteLine(cart.ProductQuantity.GetAttribute("value"));

                Assert.That(cart.ProductQuantity.GetAttribute("value").Equals("2"));

                cart.ClickOnRemoveProduct();

                IWebElement cartEmpty = fwait.Until(d => d.FindElement(By.XPath("//span[@class='font-bold'][text()='You have No Items in Cart !!! ']")));

                Console.WriteLine(cart.GetCartEmpty());
                ScreenShotTest();
                try
                {

                    Assert.That(cart.GetCartEmpty().Contains("No Item in Cart"));
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
}

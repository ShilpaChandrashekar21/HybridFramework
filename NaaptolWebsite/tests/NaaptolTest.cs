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
    [TestFixture]
    internal class NaaptolTest : CoreCodes
    {
        [Test,Category("Regression testing")]
        //[TestCase("eyewear")]
        public void SearchProductTest()
        {
            var naaptolHomePage = new NaaptolHomePage(driver);

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestExcelData/InputData.xlsx";
            string? sheetName = "NaaptolTestData";

            List<TestData> searchDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var searchData in searchDataList)
            {
                string? searchText = searchData.ProductName;

                var selectProduct = naaptolHomePage.SearchForProduct(searchText);

                Assert.That(driver.Url.Contains(searchText));

                var addProduct = selectProduct.SelectAProduct();


                List<string> lstWindow = driver.WindowHandles.ToList();

                foreach (var i in lstWindow)
                {
                    Console.WriteLine("Switching to window: " + i);
                    driver.SwitchTo().Window(i);
                }

                addProduct.SelectPowerLink();

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
                    test = extent.CreateTest("Naaptol Test - Pass");
                    test.Pass("SearchProductTest success");
                }
                catch
                {
                    test = extent.CreateTest("Naaptol Test - Fail");
                    test.Fail("SearchProductTest failed");
                }
               

                cart.ClickCloseCart();
            }

        }

        

    }
}

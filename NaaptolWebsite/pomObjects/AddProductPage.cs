using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolWebsite.pomObjects
{
    internal class AddProductPage
    {
        IWebDriver driver;
        public AddProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText,Using = "Brown-2.50")]
        public IWebElement? SelectPower {  get; set; }

        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        public IWebElement? AddSelectedProduct { get; set; }

        public void SelectSizeLink()
        {
            SelectPower?.Click();
        }

        public CartPage AddSelectedProductLink()
        {
            AddSelectedProduct?.Click();
            return new CartPage(driver);
        }
    }
}

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.pageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver) 
        { 
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName,Using = "base")]
        private IWebElement? ProductTitle { get; set; }

        //[FindsBy(How = How.ClassName,Using = "qty-inc")]
        //[FindsBy(How = How.CssSelector, Using = "a.qty-inc")]
        [FindsBy(How =How.XPath, Using = "//a[@class='qty-inc']")]
        private IWebElement ProductQuantity { get; set; }

        [FindsBy(How = How.Id, Using = "product-addtocart-button")]
        private IWebElement AddToCartButton { get; set; }

        public string? GetProductTitle()
        {
            return ProductTitle?.Text;
        }

        public void ClickOnProductQuantity()
        {
            ProductQuantity?.Click();
        }

        public void ClickOnAddToCartButton()
        {
            AddToCartButton?.Click();
        }
    }
}

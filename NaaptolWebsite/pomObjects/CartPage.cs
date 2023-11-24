using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolWebsite.pomObjects
{
    internal class CartPage
    {
        IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText,Using = "Reading Glasses with LED Lights (LRG4)")]
        public IWebElement? ProductInCart { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='head_qty']/input")]
        public IWebElement? ProductQuantity { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//p[@class='chintu']/a")]
        public IWebElement? RemoveProduct { get; set; }


        [FindsBy(How = How.XPath,Using = "//a[@title='Close']")]
        public IWebElement? CloseCart { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='font-bold'][text()='You have No Items in Cart !!! ']")]
        public IWebElement? CartEmpty { get; set; }
        
        public string GetProductInCart()
        {
            return ProductInCart?.GetAttribute("href");
        }
        public void ChangeProductQuantity()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('value', '2')",ProductQuantity);
          
        }

        public void ClickOnRemoveProduct() 
        {
            RemoveProduct?.Click();
        }

        public string GetCartEmpty()
        {
            return CartEmpty.Text;
        }
        public void ClickCloseCart()
        {
            CloseCart?.Click();
        }
    }
}

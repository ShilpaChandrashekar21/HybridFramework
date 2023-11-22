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

        [FindsBy(How = How.XPath,Using = "//a[@title='Close']")]
        public IWebElement? CloseCart { get; set; }

    

        public void ClickCloseCart()
        {
            CloseCart?.Click();
        }
    }
}

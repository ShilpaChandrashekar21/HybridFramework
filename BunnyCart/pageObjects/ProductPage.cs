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

        public string? GetProductTitle()
        {
            return ProductTitle?.Text;
        }
    }
}

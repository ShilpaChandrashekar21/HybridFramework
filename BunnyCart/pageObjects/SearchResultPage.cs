using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.pageObjects
{
    
    internal class SearchResultPage
    {
        IWebDriver driver;
        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//a[@class='product-item-link' ])[2]")]
        private IWebElement? SearchedResult {  get; }

        public string? GetSearchedResult()
        {
            return SearchedResult?.Text;
        }

        public ProductPage ClickOnSearchedResult()
        {
            SearchedResult?.Click();
            return new ProductPage(driver);
        }
    }
}

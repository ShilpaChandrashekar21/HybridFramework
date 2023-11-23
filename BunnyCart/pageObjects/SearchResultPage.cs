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


        
        public string? GetSearchedResult(int count)
        {
            IWebElement? SearchedResult = driver.FindElement(By.XPath("(//a[@class='product-item-link'])[" + count + "]"));
            //Thread.Sleep(10000);            
            return SearchedResult?.Text;
        }

        public ProductPage ClickOnSearchedResult(int count)
        {
            IWebElement? SearchedResult = driver.FindElement(By.XPath("(//a[@class='product-item-link'])[" + count + "]"));
            SearchedResult?.Click();
            return new ProductPage(driver);
        }
    }
}

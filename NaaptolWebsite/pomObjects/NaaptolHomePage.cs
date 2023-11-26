using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolWebsite.pomObjects
{
    internal class NaaptolHomePage
    {
        IWebDriver driver;
        public NaaptolHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.Id , Using = "header_search_text")]
        public IWebElement? SearchBox { get; set; }

        

        public Select5thProductPage SearchForProduct(string productName)
        {
            SearchBox?.Click();
            SearchBox?.SendKeys(productName);
            SearchBox?.SendKeys(Keys.Enter);
            return new Select5thProductPage(driver);
        }
    }
}

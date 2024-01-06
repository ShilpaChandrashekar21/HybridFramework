using AventStack.ExtentReports;
using Google.Custom_Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Google.Selenium_Tests.Pages
{
    internal class HomePage : BasePage
    {
        [CacheLookup]
        private IWebElement? SearchBar => Driver?.FindElement(By.Name("q"));

        [CacheLookup]
        private IWebElement? SearchButton => Driver?.FindElement(By.Name("btnK"));
        /*[FindsBy(How = How.Name,Using = "btnk")]
        private IWebElement? SearchButton {  get; set; }*/

        public HomePage(IWebDriver driver) : base(driver) { }

        public void EnterSearchText (string text) 
        {
            SearchBar?.SendKeys(text);
        }

        public void ClickSearchButton()
        {
            DefaultWait<IWebDriver?> fwait = new DefaultWait<IWebDriver?>(Driver);
            fwait.Timeout = TimeSpan.FromSeconds(10);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(150);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fwait.Message = " Element Not Found";

            fwait.Until(x => x?.FindElement(By.Name("btnK")));
            SearchButton?.Click();


        }

        public void SearchTest(string searchText, string testName, ExtentTest Test)
        {
            try
            {
                SearchBar?.SendKeys(searchText);
                LogTestResult(testName, "Info",Test, $"Entered search text : {searchText}");
                WaitForElementToBeClickable(SearchButton, "Google Search button");
                SearchButton?.Clear();
                LogTestResult(testName, "Info", Test, $"Clicked on the search button");

            }
            catch(Exception ex)
            {
                throw new ProjectExceptions(ex.Message);
            }


            
        }

    }
}

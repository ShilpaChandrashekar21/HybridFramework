using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNUnit
{
    [TestFixture]
    internal class Flipkart : BaseCodes
    {
        [Test]
        public void SearchTest()
        {
            driver.FindElement(By.XPath("//*[@class = '_30XB9F']")).Click();
           
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            IWebElement search = wait.Until(d=>d.FindElement(By.ClassName("Pke_EE")));
            search.SendKeys("Laptop");
          //  search.SendKeys(Keys.Enter);
           driver.FindElement(By.ClassName("_2iLD__")).Click();
        }
    }
}

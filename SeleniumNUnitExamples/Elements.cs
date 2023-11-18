using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    [TestFixture]
    internal class Elements :CoreCodes
    {
        [Test]
        public void FormTest()
        {
            driver.FindElement(By.Id("firstName")).SendKeys("Jack");
            Thread.Sleep(1000);

            driver.FindElement(By.Id("lastName")).SendKeys("Paul");
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys("jp@mail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='userNumber']")).SendKeys("1234567890");
            Thread.Sleep(1000);

            driver.FindElement(By.Id("dateOfBirthInput")).Click();
            Thread.Sleep(1000);

            IWebElement dobMonth = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            SelectElement selectMonth = new SelectElement(dobMonth);
            selectMonth.SelectByValue("8");
            Thread.Sleep(2000);

            IWebElement dobYear = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            SelectElement selectYear = new SelectElement(dobYear);
            selectYear.SelectByText("1999");
            Thread.Sleep(2000);

            IWebElement dobDate = driver.FindElement(By.XPath("//div[@class='react-datepicker__day react-datepicker__day--021']"));
            dobDate.Click();
            Thread.Sleep(2000);

            IWebElement subject = driver.FindElement(By.Id("subjectsInput"));
            subject.SendKeys("Maths");
            subject.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            subject.SendKeys("English");
            subject.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//label[text()='Sports']")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Id("uploadPicture")).SendKeys("C:\\Users\\Administrator\\Pictures\\Saved Pictures\\download.jpg");
            Thread.Sleep(2000);

            driver.FindElement(By.Id("currentAddress")).SendKeys("Bengaluru");
            Thread.Sleep(2000);



        }


    }
}

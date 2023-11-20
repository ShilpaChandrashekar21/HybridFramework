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

        [Test]
        public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string ParentWindow = driver.CurrentWindowHandle;
            Console.WriteLine("Parent Window: "+ParentWindow);
           IWebElement popUp= driver.FindElement(By.Id("tabButton"));
            for(int i = 0;i<3;i++)
            {
                popUp.Click();
                Thread.Sleep(2000);
            }

            List<string> lstWindow = driver.WindowHandles.ToList();

            foreach(var i in lstWindow)
            {
                Console.WriteLine("Switching to window: " + i);
                driver.SwitchTo().Window(i);
                Thread.Sleep(2000);
                Console.WriteLine("navigating to google.com");
                driver.Navigate().GoToUrl("https://www.google.com");
                Thread.Sleep(3000);

            }

            driver.SwitchTo().Window(ParentWindow);
            driver.Quit();
        }

        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement alerts = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", alerts);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert text is " + simpleAlert.Text);
            Thread.Sleep(3000);
            simpleAlert.Accept();

            alerts = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(3000);
            alerts.Click();
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            string alertText = confirmationAlert.Text;
            Console.WriteLine("Alert text is " + alertText);
            Thread.Sleep(3000);
            confirmationAlert.Dismiss();

            alerts = driver.FindElement(By.Id("promtButton"));
            alerts.Click();
            Thread.Sleep(3000);
            IAlert promptAlert = driver.SwitchTo().Alert();
            alertText = promptAlert.Text;
            Console.WriteLine("Alert text is " + alertText);
            promptAlert.SendKeys("Accepting the alert");
            Thread.Sleep(3000);
            confirmationAlert.Accept();


        }


    }
}

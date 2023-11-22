using Rediff.pageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.tests
{
    [TestFixture]
    internal class RediffTests : CoreCodes
    {


        //Asserts
        [Test]
        [Order(1), Category("Smoke Test")]
        public void CreateAccountLinkTest()
        {
            var homePage = new RediffHomePage(driver);//initializing all the web element in that class
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homePage.ClickOnCreateAccountLink();
            Thread.Sleep(3000);
            Assert.That(driver.Url.Contains("register"));

        }

        [Test]
        [Order(2), Category("Smoke Test")]
        public void SignInLinkTest()
        {

            var homePage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homePage.ClickOnSignInLink();
            Assert.That(driver.Url.Contains("login"));
        }

        [Test, Category("Regression Test")]
        [Order(2)]
        public void CreateAccountTest()
        {
            var homePage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            CreateAccountPage createAccountPage = homePage.ClickOnCreateAccount();
            Thread.Sleep(2000);
            createAccountPage.FullNameInput("ABC");
            createAccountPage.EmailInput("abc@gmail.com");
            createAccountPage.ClickOnCheckAvailabilityButton();
            createAccountPage.ClickOnCreateAccountButton();
        }


        [Test, Category("Regression Test")]
        [Order(1)]
        public void SignInTest()
        {
            var homePage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var signInPage = homePage.ClickOnSignIn();
            signInPage.UserNameInput("AAA");
            signInPage.UserPasswordInput("password");
            signInPage.ClickOnRememberMeCheckBox();

            Assert.False(signInPage.RememberMeCheckBox?.Selected);
            signInPage.ClickOnSignInButton();
        }

    }
}

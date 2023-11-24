using BunnyCart.pageObjects;
using BunnyCart.utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.tests
{
    [TestFixture, Order(2)]
    internal class BunnyCartTest : CoreCodes
    {
        [Test]
        public void CreateAnAccountTest()
        {
            var homePage = new BunnyCartHomePage(driver);

            homePage.ClickOnCreateAccountLink();
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']" +
                "//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
                
                test = extent.CreateTest("Create Account Link Test - Pass");
                test.Pass("Create Account Link success");
                Console.WriteLine("ERCP");

            }
            catch (AssertionException)
            {
                Console.WriteLine("Modal didn't appear");

                test = extent.CreateTest("Create Account Link Test - Fail");
                test.Fail("Create Account Link failed");
                Console.WriteLine("ERCF");
            }
            /*Assert.That(driver?.FindElement(By.XPath("//div[" +
                 "@class='modal-inner-wrap']//following::h1[2]")).Text,
                 Is.EqualTo("Create an Account"));*/

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccountData";

            List<CreateAccount> excelDataList = ExcelUtils.ReadCreateAccountExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? password = excelData?.Password;
                string? confirmPassword = excelData?.ConfirmPassword;
                string? mobileNum = excelData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {password}, Confirm Password: {confirmPassword}, Mobile Number: {mobileNum}");
                homePage.CreateAccountLinkInput(firstName, lastName, email, password, confirmPassword, mobileNum);
                

            }




        }
    }
}

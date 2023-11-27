using BunnyCart.pageObjects;
using BunnyCart.utilities;
using OpenQA.Selenium;
using Serilog;
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
        /*public void CreateAnAccountTest()
        {
            //logs
            string? curDir = Directory.GetParent(@"../../../").FullName;
            string? fileName = curDir + "/logs/log_" + 
                DateTime.Now.ToString("ddmmyyyy-hhmmss")+ ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(fileName,rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var homePage = new BunnyCartHomePage(driver);
            Log.Information("Create account test started");

            homePage.ClickOnCreateAccountLink();
            Log.Information("Created account link clicked");
            Thread.Sleep(3000);

            try
            {
                *//*Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']" +
                "//following::h1[2]")).Text, Is.EqualTo("Create an Account"));*//*

                Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']" +
                "//following::h1[2]")).Text=="Create an Account",$"Test Failed for Create Account");

                Log.Information("Test passed for Create Account");
                //extentReport
                test = extent.CreateTest("Create Account Link Test - Pass");
                test.Pass("Create Account Link success");
                //Console.WriteLine("ERCP");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for create account. \n Exception: {ex.Message}");
                //Console.WriteLine("Modal didn't appear");

                test = extent.CreateTest("Create Account Link Test - Fail");
                test.Fail("Create Account Link failed");
                //Console.WriteLine("ERCF"); //not needed for Logs
            }
            *//*Assert.That(driver?.FindElement(By.XPath("//div[" +
                 "@class='modal-inner-wrap']//following::h1[2]")).Text,
                 Is.EqualTo("Create an Account"));*//*

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
            Log.CloseAndFlush();
*/
        public void CreateAnAccountTest()
        {
            //logs
            string? curDir = Directory.GetParent(@"../../../").FullName;
            string? fileName = curDir + "/logs/log_" +
                DateTime.Now.ToString("ddmmyyyy-hhmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(fileName, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var homePage = new BunnyCartHomePage(driver);
            
            homePage.ClickOnCreateAccountLink();
            
            Thread.Sleep(3000);

            try
            {
                

                Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']" +
                "//following::h1[2]")).Text == "Create an Account", $"Test Failed for Create Account");

                LogTestResult("Create Account Link Test ", "Create Account Link success");
               
               
            }
            catch (AssertionException ex)
            {
                LogTestResult("Create Account Link Test ", $"Create Account Link failed \n Exception: {ex.Message}");
                
            }
            
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
            Log.CloseAndFlush();



        }
    }
}

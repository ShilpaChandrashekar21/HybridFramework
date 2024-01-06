using Google.Custom_Exceptions;
using Google.Selenium_Tests.Pages;
using Google.Test_Data_Classes;
using Google.Utils;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Google.Selenium_Tests.Tests
{
    internal class HomePageTest : BasePage
    {
        private HomePage homePage;
        string testName;

        [SetUp]
        public void BeforeTest()
        {
            homePage = new HomePage(Driver);
        }
        [Test]

        public void GoogleSearchTest()
        {
            testName = "Google Search Test";
            Log.Information(testName);
            Log.Information("************************************************");
            Test = Extent.CreateTest(testName);


            string? excelFilePath = currdir + "/Test Data/Google Data.xlsx";
            string? sheetName = "Search Data";

            List<SearchData> excelDataList = SearchDataRead.ReadSearchText(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? searchText = excelData.SearchText;
                LogTestResult(testName, "Info", Test, "Starting the Google search test");

                LogTestResult(testName, "Info", Test, "Opened Google homepage");

                try
                {
                    homePage.SearchTest(searchText, testName, Test);

                    // Assume the title contains the search text for simplicity
                    Assert.That(Driver.Title.Contains(searchText), Is.True, $"Search results page title does not contain '{searchText}'");
                    LogTestResult(testName, "Info", Test, "Google search test completed");
                    LogTestResult(testName, "pass", Test, testName + " - Passed");
                }
                catch (Exception ex)
                {
                    if (ex is ProjectExceptions || ex is AssertionException)
                    {
                        LogTestResult(testName, "fail", Test, testName + " - Failed", ex.Message);
                    }
                    else
                    {
                        //Log other exceptions or handle them as needed
                    }

                }
                finally
                {
                    Driver.Navigate().GoToUrl(url);
                }


            }

        }
        /*public void GoogleSearchTest()
        {

            testName = "Google Search Test";
            Log.Information(testName);
            Log.Information("************************************************");
            Test = Extent.CreateTest(testName);


            string? excelFilePath = currdir + "/Test Data/Google Data.xlsx";
            string? sheetName = "Search Data";

            List<SearchData> excelDataList = SearchDataRead.ReadSearchText(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? searchText = excelData.SearchText;


                LogTestResult(testName, "Info",Test, "Starting the Google search test");

                LogTestResult(testName, "Info", Test, "Opened Google homepage");

                homePage.EnterSearchText(searchText);
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                TakeScreenshot();
                LogTestResult(testName, "Info", Test, $"Entered search text: {searchText}");

                homePage.ClickSearchButton();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                TakeScreenshot();
                LogTestResult(testName, "Info", Test, "Clicked on the Search button");

                try
                {

                    // Assume the title contains the search text for simplicity
                    Assert.That(Driver.Title.Contains(searchText), Is.True, $"Search results page title does not contain '{searchText}'");
                    LogTestResult(testName, "Info", Test, "Google search test completed");
                    LogTestResult(testName, "pass", Test, testName + " - Passed");
                }
                catch (Exception ex)
                {
                    LogTestResult(testName, "fail", Test, testName + " - Failed", ex.Message);
                }
                finally
                {
                    Driver.Navigate().GoToUrl(url);
                }
                // Additional assertions or actions if needed
            }
        }*/

        [TearDown]
        public void AfterTest()
        {
            Driver.Navigate().GoToUrl(url);
            Log.Information("************************************************");
        }


    }
}

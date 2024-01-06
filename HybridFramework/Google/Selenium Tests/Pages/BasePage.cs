using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Selenium_Tests.Pages
{
    internal class BasePage
    {
        protected IWebDriver? Driver;

        protected ExtentReports? Extent;
        protected ExtentTest? Test;
        private ExtentSparkReporter? SparkReporter;

        private Dictionary<string, string>? Properties;
        protected string? currdir;
        protected string? url;

        //overloaded constructor
        protected BasePage()
        {
            currdir = Directory.GetParent(@"../../../")?.FullName;
        }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

       
        private void ReadConfigSettings()
        {
            Properties = new Dictionary<string, string>();
            string fileName = currdir + "/Config Settings/config.properties";
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains('='))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    Properties[key] = value;
                }
            }

        }

        protected static void ScrollIntoView(IWebDriver driver, IWebElement? element)
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

        }

        protected void TakeScreenshot()
        {
            ITakesScreenshot? takesScreenshot = (ITakesScreenshot?)Driver;
            Screenshot? screenshot = takesScreenshot?.GetScreenshot();
                        
            string filename = currdir + "/Screenshots/ss_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".png";
            screenshot?.SaveAsFile(filename);
        }

        protected void LogTestResult(string testName,string type,ExtentTest Test, string result, string? errorMessage = null)
        {
            if(type.ToLower().Equals("info"))
            {
                Log.Information(result);
                Test?.Info(result);

            }
            else if (type.ToLower().Equals("pass") && errorMessage == null)
            {
                Log.Information(testName + "Passed");
                Log.Information("------------------------------------------------------------------------");
                Test?.Pass(result);
            }
            else
            {
                Log.Error($"Test failed for {testName} \n Exception:\n{errorMessage}");
                Log.Information("------------------------------------------------------------------------");
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
                Test?.AddScreenCaptureFromBase64String(screenshot);
                Test?.Fail(result);

            }
        }

        public void InitializeBrowser()
        {
            ReadConfigSettings();
            if (Properties?["browser"].ToLower() == "chrome")
            {
                Driver = new ChromeDriver();
            }
            else if (Properties?["browser"].ToLower() == "edge")
            {
                Driver = new EdgeDriver();
            }
            url = Properties?["baseUrl"];
            Driver.Url = url;
            Driver.Manage().Window.Maximize();

        }

        [OneTimeSetUp]
        public void SetUp()
        {
            InitializeBrowser();

            //Configure Logs
            string? logfilename = currdir + "/Logs/logs_" + DateTime.Now.ToString("dd/ddMMyyyy_hhmmss") + ".txt";
            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilename,rollingInterval:RollingInterval.Day)
                .CreateLogger();

            //Extent Reports

            Extent = new ExtentReports();
            SparkReporter = new ExtentSparkReporter(currdir + "/Reports/extent-report"
                + DateTime.Now.ToString("dd/ddMMyyyy_HHmmss") + ".html");

            Extent.AttachReporter(SparkReporter);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver?.Quit();
            Extent?.Flush();
            Log.CloseAndFlush();
        }

        protected static void WaitForElementToBeClickable(IWebElement element, string elementName)
        {
            if (element != null)
            {
                DefaultWait<IWebElement?> fwait = new DefaultWait<IWebElement?>(element);
                fwait.Timeout = TimeSpan.FromSeconds(10);
                fwait.PollingInterval = TimeSpan.FromMilliseconds(150);
                fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fwait.Message = " Element - " + elementName + " - not found or " + " not clickable";

                fwait.Until(x => x != null && x.Displayed && x.Enabled);
            }
        }

    }
}

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolWebite
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties;
        public IWebDriver driver;

        public ExtentReports extent;
        ExtentSparkReporter sparkReporter;
        public ExtentTest test;
        public void ReadConfigSettings()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string fileName = currDir + "/configSettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if(!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }

        }

        [OneTimeSetUp] 
        public void InitializeBrowser() 
        {
            ReadConfigSettings();
            string currDir = Directory.GetParent(@"../../../").FullName;

            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/extentReports/extent-report"
                + DateTime.Now.ToString("yyyy_MM_dd/HH-mms-s") + ".html");

            if (properties["browser"].ToLower() == "chrome")
                {
                    driver = new ChromeDriver();
                }
                else if (properties["browser"].ToLower() == "edge")
                {
                    driver = new EdgeDriver();
                }

                driver.Url = properties["baseUrl"];
                driver.Manage().Window.Maximize();

            

        }

        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using(var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public void ScreenShotTest()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string curDir = Directory.GetParent(@"../../../").FullName;
            string filename = curDir + "/ScreenShot/ss_" + DateTime.Now.ToString("dd/mm/yyyy_hhmmss") + ".png";
            screenshot.SaveAsFile(filename);
        }

        [OneTimeTearDown] 
        public void Cleanup()
        {
            driver.Quit();
            extent.Flush();
        }
    }
}

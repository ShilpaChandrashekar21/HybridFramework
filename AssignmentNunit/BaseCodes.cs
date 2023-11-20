using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNUnit
{
    internal class BaseCodes
    {
        Dictionary<string,string> property = new Dictionary<string,string>();
        public IWebDriver driver;
        public void ReadConfigProperty()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            property = new Dictionary<string, string>();
            string fileName = currDir + "/configproperties/config.properties";
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    property[key] = value;
                }

            }
        }

        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            ReadConfigProperty();
            if (property["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (property["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }

            driver.Url = property["url"];
            driver.Manage().Window.Maximize();

        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}

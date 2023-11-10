// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver(); //opens browser
driver.Url = "https://www.google.com/";

Thread.Sleep(1000); //should never use thread.sleep in code

string title = driver.Title;
try
{
    Assert.AreEqual("Google", title);
    Console.WriteLine("Passed");

}
catch (AssertionException e)
{
   Console.WriteLine("Failed\n"+ e.Message);
}
driver.Close();



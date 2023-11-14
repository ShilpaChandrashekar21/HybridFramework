// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExamples;

Google_home_page_tests ghp = new Google_home_page_tests();
/*Console.WriteLine("Select your driver");
Console.WriteLine("1->Chrome\n2->Edge");
int ch = Convert.ToInt32(Console.ReadLine());*/
List<string> drivers = new List<string>();
drivers.Add("Chrome");
drivers.Add("Edge");
foreach (var driver in drivers)
{
    switch (driver)
    {
        case "Chrome":
            ghp.InitializeChromeDriver();
            break;
        case "Edge":
            ghp.InitializeEdgeDriver();
            break;
        
    }

    try
    {
        /*ghp.TitleTest();
        ghp.PageSourceTest();
        ghp.PageUrlTest();
        ghp.GoogleSearchTest();
        ghp.GmailLinkTest();
        ghp.ImagesLinkTest();
        ghp.LocalizationTest();*/
        ghp.GoogleAppYouTubeTest();


    }
    catch (AssertionException e)
    {
        Console.WriteLine("Failed\n" + e.Message);
    }

    ghp.End();



}





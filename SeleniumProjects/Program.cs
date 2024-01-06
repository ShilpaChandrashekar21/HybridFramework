// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExamples;


/*AmazonTests amazon = new AmazonTests();

amazon.InitializeChromeDriver();

try
{
    *//*amazon.TitleTest();
    amazon.LogoClickTest();
    Thread.Sleep(5000);
    amazon.SearchProductTest();
    Thread.Sleep(5000);
    amazon.ReloadHomePage();
    amazon.TodaysDealTest();
    Thread.Sleep(2000);
    amazon.SignInAccountListTest();*//*
    Thread.Sleep(1000);
    amazon.SearchAndFilterProductByBrandTest();
    amazon.SortBySelectTest();
   
}
catch(AssertionException e)
{
    Console.WriteLine("Failed\n"+e.Message);
}
catch(NoSuchElementException e)
{
    Console.WriteLine(e.Message);
}

amazon.End();*/

//----------------------------------------------------------------
Google_home_page_tests ghp = new Google_home_page_tests();
Console.WriteLine("Select your driver");
Console.WriteLine("1->Chrome\n2->Edge");
int ch = Convert.ToInt32(Console.ReadLine());
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
        ghp.TitleTest();
        ghp.PageSourceTest();
        ghp.PageUrlTest();
        ghp.GoogleSearchTest();
        ghp.GmailLinkTest();
        ghp.ImagesLinkTest();
        ghp.LocalizationTest();
        ghp.GoogleAppYouTubeTest();


    }
    catch (AssertionException e)
    {
        Console.WriteLine("Failed\n" + e.Message);
    }

    ghp.End();



}

public static class ClassA
{
    static int a = 5;
    public static void Method()
    {
         int b = 5;
        
        Console.WriteLine(a+b);

    }
}






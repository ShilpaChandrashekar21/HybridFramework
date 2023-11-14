// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Assignment;
using NUnit.Framework;

AmazonHomePageTest amazon = new AmazonHomePageTest();

amazon.Initialize();
try
{

    amazon.CheckTitleTest();
    amazon.CheckOrganizationTypeTest();

}
catch (AssertionException e)
{
    Console.WriteLine("Failed\n" + e.Message);
}

amazon.Destruct();

//---------------------------------------------------------------------------

/*NavigationTest nav = new NavigationTest();

nav.Initialize();
try
{

    nav.NavigatingToTest();

}
catch (AssertionException e)
{
    Console.WriteLine("Failed\n" + e.Message);
}

nav.Destruct();*/

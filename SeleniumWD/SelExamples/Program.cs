

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using SelExamples;

List<string> drivers = new List<string>();
//drivers.Add("Edge");
drivers.Add("Chrome");

foreach (var d in drivers)
{
    AmazonTests az = new AmazonTests();
    switch (d)
    {
        case "Edge":
            az.InitializeEdgeDriver(); break;
        case "Chrome":
            az.InitializeChromeDriver(); break;
    }
    try
    {
        //az.TitleTest();
        //az.LogoClickTest();
        //az.SearchProductTest();
        //az.ReloadHomePage();
        //az.TodaysDealsTest();
        //az.SignInAccListTest();
        az.SearchAndFilterProductByBrand();
        az.SortBySelectTest();
        Thread.Sleep(7000);
       

    }
    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }
    catch (NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);
    }
    az.Destruct();
}
    











/*
GHPTests ghpTests = new();
/*
Console.WriteLine("1.Edge 2.Chrome");
int ch=Convert.ToInt32(Console.ReadLine());
switch (ch)
{
    case 1:
        gHTests.InitializeEdgeDriver();break;
    case 2:
        gHTests.InitializeChromeDriver();break;
}
*/
/*
List<string> drivers = new List<string>();
drivers.Add("Edge");
drivers.Add("Chrome");
foreach (var d in drivers)
{
    switch (d)
    {
        case "Edge":
            ghpTests.InitializeEdgeDriver(); break;
        case "Chrome":
            ghpTests.InitializeChromeDriver(); break;
    }
}
try
{
    ghpTests.TitleTest();
    ghpTests.PageSourceandURLTest();
    ghpTests.GStest();
    ghpTests.GmailLinkTest();
    ghpTests.ImagesLinkTest();
    ghpTests.LocalizationTest();
    //ghpTests.GAppYoutubeTest();


}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}
ghpTests.Destruct();
*/




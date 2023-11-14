using Assignment;
using NUnit.Framework;
//Amazon
/*
AmazonTests amazonTests = new AmazonTests();

amazonTests.InitializeChromeDriver();
try
{
    amazonTests.TitleTest();
    amazonTests.OrganisationTypeTest();
}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}
amazonTests.Destruct();
*/

//Yahoo-Google

using Assignments;

GoogleYahooTests googelYahoo = new GoogleYahooTests();
googelYahoo.InitializeChromeDriver();
try
{
    googelYahoo.YahooTest();
    googelYahoo.SearhBoxTest();
}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}
googelYahoo.Destruct();

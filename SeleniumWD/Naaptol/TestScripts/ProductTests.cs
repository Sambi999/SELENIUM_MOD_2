using Naaptol.PageObjects;
using Naaptol.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.TestScripts
{
    [TestFixture]
    internal class ProductTests : CoreCodes
    {
        [Test, Order(1), Category("Regression test")]
        public void SearchProductTest()
        {
            var naaptolhomepage = new NaaptolHomePage(driver);

            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
            //naaptolhomepage.SearchClick(excelData.SearchText);


            try
            {
                Assert.That(driver.Url.Contains("naaptol"));
                test = extent.CreateTest("Search Product Test");
                test.Pass("Search product success");

            }
            catch (AssertionException)
            {
                test = extent.CreateTest("Search Product Test");
                test.Fail("Search product failed");

            }


            Assert.That(driver.Url.Contains("naaptol"));


            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "SearchProduct";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? searchText = excelData.SearchText;
                Console.WriteLine($"Search text: {searchText}");
                naaptolhomepage.SearchClick(excelData.SearchText);
                TakeScreenShot();


                var searchedProductListPage = new SearchedProductListPage(driver);
                searchedProductListPage.SelectedProduct();

                List<string> nextwindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(nextwindow[1]);


                var buyNow = new SearchedFifthProductPage(driver);
                buyNow.Sizeselect();

                buyNow.BuyNowButtonClicked();
                TakeScreenShot();


                string? qtyincrease = excelData?.QtyIncrease;
                Console.WriteLine($"Qty increase: {qtyincrease}");
                buyNow.QtyIncrease(excelData.QtyIncrease);


                buyNow.ClickRemove();
                Thread.Sleep(3000);
                buyNow.CloseButtonClicked();
                TakeScreenShot();

                driver.Close();
                Thread.Sleep(5000);
                driver.SwitchTo().Window(nextwindow[0]);
                driver.SwitchTo().DefaultContent();


            }
        }
    }
}

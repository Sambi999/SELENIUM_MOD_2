using OpenQA.Selenium;
using SeleniumNUnitExs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    [TestFixture]
    internal class GHPTests : CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(0)]
        public void TitleTest()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Title: " + driver.Title);
            Console.WriteLine("Title length: " + driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }

        //[Ignore("other")]
        [Test]
        [Order(1)]
        public void GSTest()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "\\InputData.xlsx";
            Console.WriteLine(excelFilePath);

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath);

            foreach (var excelData in excelDataList)
            {
                Console.WriteLine($"Text: {excelData.SearchText}");

                IWebElement searchInputTextBox = driver.FindElement(By.Id("APjFqb"));
                searchInputTextBox.SendKeys(excelData.SearchText);
                Thread.Sleep(2000);
                IWebElement gsButton = driver.FindElement(By.ClassName("gNO89b"));
                gsButton.Click();
                Assert.That(driver.Title, Is.EqualTo(excelData.SearchText + " - Google Search"));
                Console.WriteLine("GS test - Pass");

                driver.Navigate().GoToUrl("https://www.google.com");
            }
        }
        [Ignore("other")]
        [Test]
        [Order(2)]
        public void AllLinksStatusTest()
        {
            List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();
            foreach (var link in allLinks)
            {
                string url = link.GetAttribute("href");
                if (url == null)
                {
                    Console.WriteLine("URL is null");
                    continue;
                }
                else
                {
                    bool isWorking = CheckLinkStatus(url);
                    if (isWorking)
                    {
                        Console.WriteLine(url + " is working");
                    }
                    else
                    {
                        Console.WriteLine(url + " is not working");
                    }
                }
            }
        }

    }
}
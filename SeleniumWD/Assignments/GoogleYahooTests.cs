using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignments
{
    internal class GoogleYahooTests
    {
        IWebDriver? driver;

        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }

        public void YahooTest()
        {
            driver.Navigate().GoToUrl("https://www.yahoo.com/");
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.yahoo.com/");

        }

        public void SearhBoxTest()
        {
            driver.Navigate().Back();
            IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
            searchInputBox.SendKeys("What's new for diwali 2023?"); //to type inside the text box
            Thread.Sleep(5000);
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));
            googleSearchButton.Click();
            Assert.AreEqual("What's new for diwali 2023? - Google Search", driver.Title);
            Console.WriteLine("GoogleSearchTest - Pass");
            driver.Navigate().Refresh();

        }

        public void Destruct()
        {
            driver.Close();
        }
    }
}

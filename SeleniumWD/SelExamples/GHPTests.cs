using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelExamples
{
    internal class GHPTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
           
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();


        }
        public void InitializeChromeDriver()
        {
            
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }

            public void TitleTest()
        {
            Thread.Sleep(1000);
            //string title = driver.Title;
            Console.WriteLine("Title" + driver.Title);
            Console.WriteLine("Title Length" + driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        public void PageSourceandURLTest()
        {
            //Console.WriteLine("PS : " + driver.PageSource);
            //Console.WriteLine("PS Len : " + driver.PageSource.Length);
            //Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            
            Console.WriteLine("URL test - Pass");
        }
        public void GStest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("hp laptop");
            Thread.Sleep(3000);
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnk"));           
            gsbutton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);
            Console.WriteLine("GS Test - Pass");
        }
        public void GmailLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
            Thread.Sleep(3000);
           
            //Assert.That(driver.Title.Contains("Gmail"));
            Assert.That(driver.Url.Contains("gmail"));
            Console.WriteLine("Gmail Link - Pass");
        }
        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(5000);

            Assert.That(driver.Title.Contains("Images"));
            //Assert.That(driver.Url.Contains("gmail"));
            Console.WriteLine("Images Link - Pass");
        }
        public void LocalizationTest()
        {
            driver.Navigate().Back();
            string loc = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(3000);

            Assert.That(loc.Equals("India"));
            //Assert.That(driver.Url.Contains("gmail"));
            Console.WriteLine("Loc - Pass");
        }

        public void GAppYoutube()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.ClassName(""));
            Thread.Sleep(3000);
            Assert.That("Youtube".Equals(driver.Title));
        }

            public void Destruct()
        {
            driver.Close();
        }
    }
}

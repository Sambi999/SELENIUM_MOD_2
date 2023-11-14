using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class AmazonTests
    {
        IWebDriver? driver;

        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }

        public void TitleTest() //to test the title
        {
            Thread.Sleep(2000);  //for delay
            Console.WriteLine("title" + driver.Title);
            //Console.WriteLine("Titile length " + driver.Title.Length);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title); //checking the title
            Console.WriteLine("Title test - Pass");
        }

        public void OrganisationTypeTest()
        {
            Assert.That(driver.Url.Contains(".com"));
            Console.WriteLine("OrganisationTypeTest- Pass");
        }

        public void Destruct()
        {
            driver.Close();
        }
    }
}
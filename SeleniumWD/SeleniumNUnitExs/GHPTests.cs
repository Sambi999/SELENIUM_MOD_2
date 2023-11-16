using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExs
{
    [TestFixture]
    internal class GHPTests : CoreCodes
    {
        [Test]
        [Order(10)]
        public void  TitleTest()
        {
            Thread.Sleep(2000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        [Test]
        [Order(20)]
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
        [Test]
        public void AllLinksStatusTest()
        {
            List<IWebElement> allLinks =
                driver.FindElements(By.TagName("a")).ToList();
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
                    bool isworking = CheckLinkStatus(url);
                    if (isworking)
                        Console.WriteLine(url + " is Working ");
                    else
                        Console.WriteLine(url + " is NOT Working ");
                }
            }
        }
    }
}

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using NunitAssignment;

namespace NunitAssignment
{
    /*
    [TestFixture]
    internal class NaaptolTests : Corecode
    {
        [Order(1)]
        [Test]
        public void SearchTest()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement searchelement = fluentwait.Until(x => x.FindElement(By.Id("header_search_text")));
            searchelement.SendKeys("eyewear");
            Assert.IsTrue(true);
            searchelement.SendKeys(Keys.Enter);
        }
        [Order(2)]
        [Test]
        [TestCase(5)]
        public void SelectProductTest(int pid)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            string path = "//div[@id='productItem" + pid + "']";
            IWebElement fndProductfive = fluentwait.Until(x => x.FindElement(By.XPath(path)));
            Actions actions = new Actions(driver);
            Action action = () => actions.MoveToElement(fndProductfive).
            Click().
            Build().
            Perform();
            action.Invoke();
            Thread.Sleep(3000);
            List<string> lswindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lswindow[1]);
            Assert.IsTrue(lswindow.Count > 0);
        }
        [Order(3)]
        [Test]
        public void Selectsize()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement selectSize = fluentwait.Until(x => x.FindElement(By.XPath("//a[text()='Black-3.00']")));
            Actions actions = new Actions(driver);
            Action action = () => actions.MoveToElement(selectSize).
            Click().
            Build().
            Perform();
            Thread.Sleep(20);
            action.Invoke();
            Assert.AreEqual("Buy Reading Glasses with LED Lights (LRG4) Online at Best Price in India on Naaptol.com", driver.Title);
        }
        [Order(4)]
        [Test]
        public void AddtoCartTest()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement buybutton = fluentwait.Until(x => x.FindElement(By.XPath("//a[@id='cart-panel-button-0']")));
            Actions btnactions = new Actions(driver);
            Action btnaction = () => btnactions.MoveToElement(buybutton).
            Click().
            Build().
            Perform();

            btnaction.Invoke();
            Assert.That(driver.Url.Contains("reading-glasses-with-led-lights-lrg4"));
            Thread.Sleep(3000);

        }
        [Order(5)]
        [Test]
        public void CloseTest()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";

            IWebElement closebtn = fluentwait.Until(x => x.FindElement(By.XPath("//a[@class='fancybox-item fancybox-close']")));
            IWebElement id = driver.FindElement(By.XPath("//*[text()='My Shopping Cart: ']"));
            Console.WriteLine(id.Text);
            Assert.That(id.Text == "My Shopping Cart: At present, you have (1) items.");
            Console.WriteLine("sussess");
            closebtn.Click();
            Thread.Sleep(2000);

        }

    }
    */
    [TestFixture]
    internal class NaaptolTests : Corecode
    {
        [Test]
        [Order(1)]
        public void SearchProductTest()
        {
            driver.Navigate().GoToUrl("https://www.naaptol.com/");

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement searchInput = fluentWait.Until(d => d.FindElement(By.Id("header_search_text")));

            searchInput.SendKeys("eyewear");
            searchInput.SendKeys(Keys.Enter);

            Assert.That(driver.Url.Contains("eyewear"));
        }

        [Test]
        [Order(2)]
        [TestCase(5)]
        public void SelectFifthProductTest(int pid)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            string path = "//div[@id='productItem" + pid + "']";
            Console.WriteLine(path);
            IWebElement clickFifthProduct = fluentWait.Until(d => d.FindElement(By.XPath(path)));

            Actions actions = new Actions(driver);
            Action scroll = () => actions
            .MoveToElement(clickFifthProduct).Click()
            .Build()
            .Perform();

            scroll.Invoke();

            List<string> liswindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(liswindow[1]);
            Assert.That(driver.Url.Contains("reading-glasses-with-led-lights-lrg4"));
        }

        [Test]
        [Order(3)]
        [TestCase("2.50")]
        public void AddProductToCartTest(string size)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            string path = "Black-" + size;

            Console.WriteLine(path);
            IWebElement chooseSize = fluentWait.Until(d => d.FindElement(By.LinkText(path)));

            chooseSize.Click();

            IWebElement clickHereToByButton = driver.FindElement(By.Id("cart-panel-button-0"));
            clickHereToByButton.Click();

            IWebElement prodName = fluentWait.Until(d => d.FindElement(By.LinkText("Reading Glasses with LED Lights (LRG4)")));
            Assert.AreEqual("Reading Glasses with LED Lights (LRG4)", prodName.Text);
        }

        [Test]
        [Order(4)]
        public void ViewShoppingCartTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement closeButton = fluentWait.Until(d => d.FindElement(By.XPath("//a[@title='Close']")));
            closeButton.Click();

            string link = "https://www.naaptol.com/eyewear/reading-glasses-with-led-lights-lrg4/p/12612074.html";
            Assert.AreEqual(driver.Url, link);

        }

    }

}



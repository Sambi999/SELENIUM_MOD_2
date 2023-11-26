using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    [TestFixture]
    internal class ActionsEvents : CoreCodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homelink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomelink = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]"));

            Actions actions = new Actions(driver);
            Action mouseOverHomeLink = () => actions
            .MoveToElement(homelink)
            .Build()
            .Perform();

            Console.WriteLine("Before : " + tdhomelink.GetCssValue("background-color"));

            mouseOverHomeLink.Invoke();

            Console.WriteLine("After : " + tdhomelink.GetCssValue("background-color"));
            Thread.Sleep(1000);

        }

        [Test]
        public void MultipleActionsTest()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));

            Actions actions = new Actions(driver);
            Action upperCaseInput = () => actions
            .KeyDown(Keys.Shift)
            .SendKeys(emailInput, "abcd")
            .KeyUp(Keys.Shift)
            .Build()
            .Perform();

            upperCaseInput.Invoke();

            Console.WriteLine("Text is " + emailInput.GetAttribute("value"));

            Thread.Sleep(3000);

        }
    }
}

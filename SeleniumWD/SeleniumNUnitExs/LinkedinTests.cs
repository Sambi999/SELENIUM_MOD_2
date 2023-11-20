using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.FedCm;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExs
{
    [TestFixture]
    internal class LinkedinTests : CoreCodes
    {
        [Test]
        [Author("Sambi", "sambi@ust.com")]
        [Description("Check for Valid Login")]
        [Category("Regression Testing")]
        public void LoginTest()
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            // IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            // IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));

            //IWebElement emailInput = wait.Until(driv => driv.FindElement(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(driv => driv.FindElement(By.Id("session_password")));

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys("abd@tuv.com");
            passwordInput.SendKeys("18909");


        }
        /*
        [Test, Author("Sambi", "sambi@ust.com")]
        [Description("Check for Invalid Login"), Category("Smoke Testing")]

        public void LoginTestInvalidCred()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys("abd@tuv.com");
            passwordInput.SendKeys("18909");
            Thread.Sleep(3000);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            emailInput.SendKeys("yedgye@uede.com");
            passwordInput.SendKeys("39434");
            Thread.Sleep(3000);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            emailInput.SendKeys("euhe@wywue.com");
            passwordInput.SendKeys("745847");
            Thread.Sleep(3000);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            Thread.Sleep(3000);
        }*/
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }

        /*
        [Test, Author("MMM", "abc@xyz.com")]
        [Description("Check for Invaid Login"), Category("Regression Testing")]
        [TestCase("abd@tuv.com", "18909")]
        [TestCase("yedgye@uede.com", "39434")]
        [TestCase("euhe@wywue.com", "745847")]
        public void LoginTestWithInvalidCred(string email, string pwd)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            Thread.Sleep(3000);

        }*/
        [Test, Author("MMM", "abc@xyz.com")]
        [Description("Check for Invaid Login"), Category("Regression Testing")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void LoginTestWithInvalidCred(string email, string pwd)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            Thread.Sleep(3000);

        }
        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] { "abc@xyz.com", "1234" },
                new object[] { "default@xyz.com", "5678" },
            };
        }
    }
}

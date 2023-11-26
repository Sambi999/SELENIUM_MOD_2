using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumNUnitExs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    [TestFixture]
    internal class LinkedinTests : CoreCodes
    {
        [Test]
        [Author("Brunda", "brunda@gmail.com")]
        [Description("Check for valid login")]
        [Category("Regression testing")]
        public void Login1Test()
        {
            //Implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //old method Explicit
            //IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            //IWebElement passwordInput= wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));

            ////new method Explicit
            //IWebElement emailInput = wait.Until(d=>d.FindElement(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(d=>d.FindElement(By.Id("session_password")));


            //fluent wait
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            emailInput.SendKeys("abc@gmail.com");
            passwordInput.SendKeys("12345");
        }


        //[Test]
        //[Author("Brunda", "brunda@gmail.com")]
        //[Description("Check for invalid login")]
        //[Category("Smoke testing")]
        //public void LoginTestWithInvalidData()
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(10);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element not found";

        //    IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
        //    emailInput.SendKeys("abc@gmail.com");
        //    passwordInput.SendKeys("123");
        //    Thread.Sleep(3000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //    emailInput.SendKeys("def@gmail.com");
        //    passwordInput.SendKeys("456");
        //    Thread.Sleep(3000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //    emailInput.SendKeys("ghi@gmail.com");
        //    passwordInput.SendKeys("789");
        //    Thread.Sleep(3000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //    Thread.Sleep(3000);
        //}
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }


        //[Test]
        //[Author("AAA", "AAA@gmail.com")]
        //[Description("Check for invalid login")]
        //[Category("Regression testing")]
        //[TestCase("abc@gmail.com","123")]
        //[TestCase("def@gmail.com","456")]
        //[TestCase("ghi@gmail.com","789")]
        //public void LoginTestWithInvalidData(string email,string password)
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(10);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element not found";

        //    IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

        //    emailInput.SendKeys(email); 
        //    passwordInput.SendKeys(password);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //}

        [Test]
        [Author("AAA", "AAA@gmail.com")]
        [Description("Check for invalid login")]
        [Category("Regression testing")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void LoginTestWithInvalidData(string email, string password)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            TakeScreenShot();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type='submit']")));

            Thread.Sleep(5000);
            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@type='submit']")));


            ClearForm(emailInput);
            ClearForm(passwordInput);

        }
        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] {"abc@gmail.com","123"},
                new object[] {"def@gmail.com","456"},

            };
        }


    }
}
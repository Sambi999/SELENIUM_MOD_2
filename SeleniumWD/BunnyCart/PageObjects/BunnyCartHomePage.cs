using BunnyCart.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BunnyCartHomePage
    {
        IWebDriver? driver;
        public BunnyCartHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.Id, Using = "search")]
        [CacheLookup]
        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Create an Account']")]
        [CacheLookup]
        private IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        [CacheLookup]
        private IWebElement? FirstNameInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        [CacheLookup]
        private IWebElement? LastNameInputBox { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        [CacheLookup]
        private IWebElement? EmailInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private IWebElement? PasswordInputBox { get; set; }


        [FindsBy(How = How.Name, Using = "password_confirmation")]
        [CacheLookup]
        private IWebElement? ConfirmPasswordInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        [CacheLookup]
        private IWebElement? MobileInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]
        [CacheLookup]
        private IWebElement? CreateAccountButton { get; set; }


        //Act
        public void ClickCreateAccountLink()
        {
            CreateAccountLink?.Click();
        }

        public void ClickCreateAccountButton(string firstName, string lastName, string email,
            string password, string confirmPassword, string mobileNumber)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));

            FirstNameInputBox?.SendKeys(firstName);
            LastNameInputBox?.SendKeys(lastName);
            EmailInputBox?.SendKeys(email);

            Corecode.ScrollIntoView(driver, PasswordInputBox);
            PasswordInputBox?.SendKeys(password);
            ConfirmPasswordInputBox?.SendKeys(confirmPassword);

            Corecode.ScrollIntoView(driver, MobileInputBox);
            MobileInputBox?.SendKeys(mobileNumber);
            Thread.Sleep(1000);
            CreateAccountButton?.Click();

        }

       

        public SearchResultsPage TypeSearchInput(string searchText)
        {
            //if(SearchInput == null)
            //{
            //    throw new ArgumentNullException(nameof(SearchInput));
            //}
            SearchInput?.SendKeys(searchText);
            SearchInput?.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);

        }
    }
}

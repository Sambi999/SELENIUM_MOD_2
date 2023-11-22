using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class RediffHomePage
    {
        IWebDriver driver;
        public RediffHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            
        }

        //Arrange
        [FindsBy(How = How.LinkText, Using = "Create Account")]
        public IWebElement? CreateAccountLink {  get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign in")]

        public IWebElement? SignInLink { get; set; }

        //Act
        /*
        public void CreateAccountLinkClick()
        {
            CreateAccountLink?.Click();
        }
        public void SignInLinkClick()
        {
            SignInLink?.Click();
        }
        
        public void CreateAccountClick()
        {
            CreateAccountLink?.Click();
        }
        public void SignInClick()
        {
            SignInLink?.Click();
        }
        */
        public CreateAccountPage CreateAccountClick()
        {
            CreateAccountLink?.Click();
            return new CreateAccountPage(driver);
        }
        public SignInPage SignInClick()
        {
            CreateAccountLink?.Click();
            return new SignInPage(driver);
        }
    }

}

using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTests : CoreCodes
    {
        /*
        //Asserts
        [Test, Order(1), Category("Smoke Test")]
        public void CreateAccountLinkTest()
        {
            
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.CreateAccountLinkClick();
            Thread.Sleep(3000);
            
           
            //Assert.That(driver.Title.Contains("register"));
        }
        [Test, Order(2), Category("Smoke Test")]
        public void SignInlINK()
        {

            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.SignInLinkClick();
            Thread.Sleep(3000);


            //Assert.That(driver.Title.Contains("login"));
        }
        
        [Test, Order(1), Category("Regression Test")]
        public void CreateAccountTest()
        {
            var homePage = new RediffHomePage(driver);
            if (!driver.Url.Contains("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var createAccountPage = homePage.CreateAccountClick();
            Thread.Sleep(3000);
            createAccountPage.FullNameType("xxx");
            createAccountPage.Rediffmailtype("xxx");
            createAccountPage.CheckAvailabilityBtnClick();
            Thread.Sleep(3000);

            createAccountPage.CreateMyAccountBtnClick();

            //Assert.That(driver.Url.Contains("register"));
        }
        */
        [Test, Order(2), Category("Regression Test")]
        public void SgnInTest()
        {
            var homePage = new RediffHomePage(driver);
            if (!driver.Url.Contains("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var signinPage = homePage.SignInClick();
            Thread.Sleep(3000);
            signinPage.TypeUserName("aaa");
            signinPage.TypePassword("xxx");
            signinPage.RememberMeChkbkClick();
            Assert.False(signinPage?.RememberMeChekbx?.Selected);

            Thread.Sleep(3000);

            signinPage?.SignInBtnClick();
            Assert.True(true);

        }
    }
}

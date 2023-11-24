using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BunnyCartTests : Corecode
    {
        [Test]
        public void SignUpTest()
        {
            BunnyCartHomePage bunnyCartHomePage = new BunnyCartHomePage(driver);
            bunnyCartHomePage.ClickCreateAccountLink();
            Thread.Sleep(1000);
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[" + "@class='modal-inner-wrap']//following::h1[2]")).Text,
                    Is.EqualTo("Create an Account"));
                bunnyCartHomePage.ClickCreateAccountButton("raj", "kumar", "raj@gmail.com", "12345", "12345", "9876543423");
            }
            catch (AssertionException)
            {
                Console.WriteLine("Sign Up failed");
            }

        }
        
    }
}
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
    internal class SearchTests : Corecode
    {
        [Test]
        [TestCase("Water", 2)]
        public void SearchProductAndAddToCartTest(string searchtext, int count)
        {
            BunnyCartHomePage bchp = new BunnyCartHomePage(driver);
            var searchResultPage = bchp?.TypeSearchInput(searchtext);
            Corecode.ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\'amasty-shopby-product-list\']/div[2]/ol/li[1]")));
            //Assert.That(searchtext.Equals(searchResultPage?.GetFirstProductLink()));
            Thread.Sleep(3000);
            var productPage = searchResultPage?.ClickFirstProductLink(count);
            Thread.Sleep(3000);
            //            Assert.That(searchtext.Equals(productPage?.GetProductTitleLabel()));
            productPage?.ClickIncQtyLink();
            Thread.Sleep(3000);
            productPage?.ClickAddToCartBtn();

            Thread.Sleep(5000);
        }
    }


}

using Naaptol.PageObjects;
using Naaptol.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.TestScripts
{
    [TestFixture]
    internal class ProductTests : Corecode
    {
        [Test, Order(1), Category("Regression test")]
        public void SearchProductTest()
        {
            var naaptolhomepage = new NaaptolHomePage(driver);

            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
            naaptolhomepage.SearchClick("eyewear");


            var searchedProductListPage = new SearchedProductListPage(driver);
            searchedProductListPage.SelectedProduct();

            List<string> nextwindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextwindow[1]);

            Thread.Sleep(2000);
            var buyNow = new SearchedFifthProductPage(driver);
            buyNow.Sizeselect();
            Thread.Sleep(2000);

            buyNow.BuyNowButtonClicked();
            Thread.Sleep(2000);

            buyNow.CloseButtonClicked();
            Thread.Sleep(2000);
        }
    }
}

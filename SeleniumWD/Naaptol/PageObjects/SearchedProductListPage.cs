using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class SearchedProductListPage
    {
        IWebDriver? driver;
        public SearchedProductListPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.XPath, Using = "//div[@id='productItem5' and @pid='12612074']")]
        public IWebElement? SelectProduct { get; set; }

        //Act
        public SearchedProductListPage SelectedProduct()
        {
            SelectProduct?.Click();
            return new SearchedProductListPage(driver);
        }
    }
}

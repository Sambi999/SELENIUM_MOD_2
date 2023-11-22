using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class SearchedFifthProductPage
    {
        IWebDriver? driver;
        public SearchedFifthProductPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.XPath, Using = "//a[text()='Black-2.50']")]
        public IWebElement? SelectedSize { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='cart-panel-button-0']")]
        public IWebElement? BuyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='fancybox-item fancybox-close']")]
        public IWebElement? CloseButton { get; set; }

        public void Sizeselect()
        {
            SelectedSize?.Click();
        }
        public void BuyNowButtonClicked()
        {
            BuyButton?.Click();
        }
        public void CloseButtonClicked()
        {
            CloseButton?.Click();
        }
    }
       

}

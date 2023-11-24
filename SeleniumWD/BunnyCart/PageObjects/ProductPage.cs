using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class ProductPage
    {
        
        IWebDriver driver;
        public ProductPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            
        }
        [FindsBy(How = How.XPath, Using = " //h1[@class='page-title']")]
        private IWebElement? ProductTitleLabel { get; }

        [FindsBy(How = How.ClassName, Using = " qty-inc")]
        private IWebElement? IncQtyLink { get; }

        [FindsBy(How = How.Id, Using = " product-addtpocart-button")]
        private IWebElement?AddToCartBtn { get; set; }

        public string? GetProductTitleLabel()
        {
            return ProductTitleLabel?.Text;
        }
        public void ClickIncQtyLink()
        {
            IncQtyLink?.Click();
        }
        public void ClickAddToCartBtn()
        {
            AddToCartBtn?.Click();
        }





    }
    
}


using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using CompleteCodes.Utilities;
using PageFactoryCore;

namespace CompleteCodes.PageObjects
{
    internal class HomePage
    {

        IWebDriver driver;
        public HomePage(IWebDriver driver)
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
        private IWebElement? CreateAnAccountLink { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement? FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastNameInput { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement? EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInput { get; set; }

        [FindsBy(How = How.Name, Using = "password_confirmation")]
        private IWebElement? ConfirmPasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]
        private IWebElement? SignUpButton { get; set; }

        //Act
        public void ClickCreateAnAccountLink()
        {
            CreateAnAccountLink?.Click();
        }

        /* public void SignUp(string firstName, string lastName, string email,
             string pwd, string conpwd, string mbno)
         {
             IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                 .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                     By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));

             FirstNameInput?.SendKeys(firstName);
             LastNameInput?.SendKeys(lastName);
             EmailInput?.SendKeys(email);

             CoreCodes.ScrollIntoView(driver, PasswordInput);
             PasswordInput?.SendKeys(pwd);
             ConfirmPasswordInput?.SendKeys(conpwd);

             CoreCodes.ScrollIntoView(driver, MobileNumberInput);
             MobileNumberInput?.SendKeys(mbno);
             Thread.Sleep(1000);
             SignUpButton?.Click();
         }
 */
        public void CreateAccount(string firstName, string lastName, string email,
            string pwd, string conpwd, string mbno)
        {
            FirstNameInput?.SendKeys(firstName);
            LastNameInput?.SendKeys(lastName);
            EmailInput?.SendKeys(email);

            CoreCodes.ScrollIntoView(driver, PasswordInput);
            PasswordInput?.SendKeys(pwd);
            ConfirmPasswordInput?.SendKeys(conpwd);

            CoreCodes.ScrollIntoView(driver, MobileNumberInput);
            MobileNumberInput?.SendKeys(mbno);
            Thread.Sleep(1000);
            SignUpButton?.Click();

        }
    }
}
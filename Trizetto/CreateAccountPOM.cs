using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Trizetto
{
    public class CreateAccountPOM
    {

        private readonly IWebDriver _driver;
        public CreateAccountPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Your Personal Information Locators
        public By EmailAddressLocator => By.Id("email_create");
        public By CreateAccountButtonLocator  => By.Name("SubmitCreate");
        public By CustomerFirstNameLocator => By.Id("customer_firstname");
        public By CustomerLastNameLocator => By.Id("customer_lastname");
        public By EmailLocator => By.Id("email");
        public By PasswordLocator => By.Id("passwd");
        #endregion

        #region Your Address Locator
        public By FirstNameLocator => By.Id("firstname");
        public By LastNameLocator => By.Id("lastname");
        public By AddressLocator => By.Id("address1");
        public By CityLocator => By.Id("city");
        public By StateLocator => By.Id("id_state");
        public By ZipcodeLocator => By.Id("postcode");
        public By CountryLocator => By.Id("id_country");
        public By MobilePhoneLocator => By.Id("phone_mobile");
        public By AliasLocator => By.Id("alias");
        public By RegisterButtonLocator => By.Id("submitAccount");
        #endregion

        #region Your Personal Information Webelemets
        public IWebElement EmailAddress => _driver.FindElement(EmailAddressLocator);
        public IWebElement CreateAccountButton => _driver.FindElement(CreateAccountButtonLocator);
        public IWebElement CustomerFirstName => _driver.FindElement(CustomerFirstNameLocator);
        public IWebElement CustomerLastName => _driver.FindElement(CustomerLastNameLocator);
        public IWebElement Email => _driver.FindElement(EmailLocator);
        public IWebElement Password => _driver.FindElement(PasswordLocator);
        #endregion

        #region Your Address Webelemets
        public IWebElement FirstName => _driver.FindElement(FirstNameLocator);
        public IWebElement LastName => _driver.FindElement(LastNameLocator);
        public IWebElement Address => _driver.FindElement(AddressLocator);
        public IWebElement City => _driver.FindElement(CityLocator);
        public SelectElement State => new SelectElement(_driver.FindElement(StateLocator));
        public IWebElement Zipcode => _driver.FindElement(ZipcodeLocator);
        public SelectElement Country => new SelectElement(_driver.FindElement(CountryLocator));
        public IWebElement MobilePhone => _driver.FindElement(MobilePhoneLocator);
        public IWebElement Alias => _driver.FindElement(AliasLocator);
        public IWebElement RegisterButton => _driver.FindElement(RegisterButtonLocator);
        #endregion
    }
}

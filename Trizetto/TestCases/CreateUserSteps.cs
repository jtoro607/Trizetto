using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Trizetto.DriverFactory;
using Xunit;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Trizetto.TestCases
{

    [Binding]
    [Scope(Feature = "CreateUser")]
    public class CreateUserSteps 
    {
        #region Declarations
        private IWebDriver _driver;
        private string _firstName;
        private string _lastName;
        private string _email;
        private readonly HomePagePOM _homePagePOM;
        private readonly CreateAccountPOM _createAccountPOM;
        private readonly Drivers _driverFactory;
        #endregion

        public CreateUserSteps()
        {
            _driverFactory = new Drivers();
            _driver = _driverFactory.GetChromDriver();
            _homePagePOM = new HomePagePOM(_driver);
            _createAccountPOM = new CreateAccountPOM(_driver);
        }

        [Given(@"I am on web page '(.*)'")]
        public void GivenIAmOnWebPage(string webLink)
        {
            _driver.Navigate().GoToUrl(webLink);
        }

        [Given(@"I click on Sign In button")]
        public void GivenIClickOnSignInButton()
        {
            _homePagePOM.Signin.Click();
        }

        [When(@"I enter email address (.*) in Create Account section")]
        public void WhenIEnterEmailAddressInCreateAccountSection(string email)
        {
            _createAccountPOM.EmailAddress.SendKeys(email);
        }

        [When(@"I click on Create an Account button")]
        public void WhenIClickOnCreateAnAccountButton()
        {
            _createAccountPOM.CreateAccountButton.Click();
        }

        [Then(@"I enter (.*) (.*) (.*) (.*)")]
        public void ThenIEnter(string firstName, string lastName, string email, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(_createAccountPOM.CustomerFirstNameLocator));

            _createAccountPOM.CustomerFirstName.SendKeys(firstName);
            _createAccountPOM.CustomerLastName.SendKeys(lastName);

            var validateEmail = _createAccountPOM.Email.GetAttribute("value");
            if (!validateEmail.Contains(email)) Assert.True(false, $"Email field does not autopopulate email value: {email}");
            
            _createAccountPOM.Password.SendKeys(password);
        }

        [Then(@"I also enter on Address section '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', (.*), and '(.*)'")]
        public void ThenIAlsoEnterOnAddressSectionAnd(string address, string city, string state, string zipcode, string country, string mobile, string alias)
        {
            _homePagePOM.ScrollToElement(_driver, _createAccountPOM.FirstName);
            var validateFirstName = _createAccountPOM.FirstName.GetAttribute("value");

            if (!validateFirstName.Contains(_firstName))
            {
                Assert.True(false, "Email field does not autopopulate First Name value");
            }

            if (!_createAccountPOM.LastName.GetAttribute("value").Contains(_lastName))
                Assert.True(false, "Email field does not autopopulate Last name value");

            _createAccountPOM.Address.SendKeys(address);
            _createAccountPOM.City.SendKeys(city);
            _createAccountPOM.State.SelectByText(state);
            _createAccountPOM.Zipcode.SendKeys(zipcode);
            _createAccountPOM.Country.SelectByText(country);
            _createAccountPOM.MobilePhone.SendKeys(mobile);
            _createAccountPOM.Alias.Clear();
            _createAccountPOM.Alias.SendKeys(alias);
        }

        [Then(@"I click on Register button")]
        public void ThenIClickOnRegisterButton()
        {
            _createAccountPOM.RegisterButton.Click();
        }

        [Then(@"Assert the logged use in the same first/last name that you entered")]
        public void ThenAssertTheLoggedUseInTheSameFirstLastNameThatYouEntered()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(_homePagePOM.AccountInfoLocator));

            var user = _homePagePOM.AccountInfo.Text;
            if (!user.Contains(_firstName) || !user.Contains(_lastName))
            {
                Assert.True(false, $"User name {_firstName} {_lastName} is not displayed after login");
            }
        }

        [AfterScenario]
        private void QuitDriver()
        {
            _driverFactory.QuitDriver();
        }

    }
}

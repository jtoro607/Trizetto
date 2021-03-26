using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Trizetto.TestCases
{

    [Binding]
    [Scope(Feature = "CreateUser")]
    public class CreateUserSteps 
    {
        private IWebDriver _driver;
        private string _firstName;
        private string _lastName;
        private string _email;

        public CreateUserSteps()
        {

        }


        [Given(@"I am on web page '(.*)'")]
        public void GivenIAmOnWebPage(string webLink)
        {
            _driver = GetChromDriver();
            _driver.Navigate().GoToUrl(webLink);
        }

        [Given(@"I click on Sign In button")]
        public void GivenIClickOnSignInButton()
        {
            _driver.FindElement(By.ClassName("login")).Click();
        }

        [When(@"I enter email address (.*) in Create Account section")]
        public void WhenIEnterEmailAddressInCreateAccountSection(string email)
        {
            _driver.FindElement(By.Id("email_create")).SendKeys(email);
        }

        [When(@"I click on Create an Account button")]
        public void WhenIClickOnCreateAnAccountButton()
        {
            _driver.FindElement(By.Name("SubmitCreate")).Click();
        }

        [Then(@"I enter (.*) (.*) (.*) (.*)")]
        public void ThenIEnter(string firstName, string lastName, string email, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("customer_firstname")));

            _driver.FindElement(By.Id("customer_firstname")).SendKeys(firstName);
            _driver.FindElement(By.Id("customer_lastname")).SendKeys(lastName);

            var validateEmail = _driver.FindElement(By.Id("email")).GetAttribute("value");
            if (!validateEmail.Contains(email))
            {
                Assert.True(false, $"Email field does not autopopulate email value: {email}");
            }
            _driver.FindElement(By.Id("passwd")).SendKeys(password);
        }

        [Then(@"I also enter on Address section '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', (.*), and '(.*)'")]
        public void ThenIAlsoEnterOnAddressSectionAnd(string address, string city, string state, string zipcode, string country, string mobile, string alias)
        {
            var test = _driver.FindElement(By.Id("city")).Location.Y;
            var validateFirstName = _driver.FindElement(By.Id("firstname")).GetAttribute("value");
            if (!validateFirstName.Contains(_firstName))
            {
                Assert.True(false, "Email field does not autopopulate First Name value");
            }

            var validateLastName = _driver.FindElement(By.Id("lastname")).GetAttribute("value");
            if (!validateLastName.Contains(_lastName))
            {
                Assert.True(false, "Email field does not autopopulate Last name value");
            }

            _driver.FindElement(By.Id("address1")).SendKeys(address);
            _driver.FindElement(By.Id("city")).SendKeys(city);

            SelectElement selectState = new SelectElement(_driver.FindElement(By.Id("id_state")));
            selectState.SelectByText(state);

            _driver.FindElement(By.Id("postcode")).SendKeys(zipcode);

            SelectElement se = new SelectElement(_driver.FindElement(By.Id("id_country")));
            se.SelectByText(country);

            _driver.FindElement(By.Id("phone_mobile")).SendKeys(mobile);

            _driver.FindElement(By.Id("alias")).Clear();
            _driver.FindElement(By.Id("alias")).SendKeys(alias);
        }

        [Then(@"I click on Register button")]
        public void ThenIClickOnRegisterButton()
        {
            _driver.FindElement(By.Id("submitAccount")).Click();
        }

        [Then(@"Assert the logged use in the same first/last name that you entered")]
        public void ThenAssertTheLoggedUseInTheSameFirstLastNameThatYouEntered()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("account")));
            var user = _driver.FindElement(By.ClassName("account")).Text;
            if (!user.Contains(_firstName) || !user.Contains(_lastName))
            {
                Assert.True(false, $"User name {_firstName} {_lastName} is not displayed after login");
            }
        }




        private IWebDriver GetChromDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-Maximized");
            return new ChromeDriver(options);
        }

        [AfterScenario]
        private void QuitDriver()
        {
            _driver.Close();
            _driver.Quit();
        }

    }
}

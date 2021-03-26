using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Trizetto.TestCases
{

    [Binding]
    [Scope(Feature = "CreateUser")]
    public class CreateUserSteps 
    {
        private IWebDriver _driver;

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
        }

        [When(@"I enter email address (.*) in Create Account section")]
        public void WhenIEnterEmailAddressInCreateAccountSection(string p0)
        {
        }

        [When(@"I click on Create an Account button")]
        public void WhenIClickOnCreateAnAccountButton()
        {
        }

        [Then(@"I enter (.*) (.*) (.*) (.*)")]
        public void ThenIEnter(string p0, string p1, string p2, string p3)
        {
        }

        private IWebDriver GetChromDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-Maximized");
            return new ChromeDriver(options);
        }

    }
}

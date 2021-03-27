using OpenQA.Selenium;
using System;

namespace Trizetto
{
    public class HomePagePOM
    {
        private readonly IWebDriver _driver;
        public HomePagePOM(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", element.Location.X, element.Location.Y));
        }

        #region Locator
        public By SigninLocator => By.ClassName("login");
        public By AccountInfoLocator => By.ClassName("account");
        #endregion

        #region WebElements
        public IWebElement Signin => _driver.FindElement(SigninLocator);
        public IWebElement AccountInfo => _driver.FindElement(AccountInfoLocator);
        #endregion
    }
}

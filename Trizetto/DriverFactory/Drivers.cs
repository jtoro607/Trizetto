using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Trizetto.DriverFactory
{
    public class Drivers
    {
        IWebDriver _driver;
        public Drivers()
        {
        }

        public IWebDriver GetChromDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-Maximized");
            _driver = new ChromeDriver(options);
            return _driver;
        }

        public void QuitDriver()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}

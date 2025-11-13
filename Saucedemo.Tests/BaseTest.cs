using OpenQA.Selenium;
using Saucedemo.CLL;
using Saucedemo.BLL;

namespace Saucedemo.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;

        protected BaseTest()
        {
            driver = WebDriverSelector.CreateWebDriver(Configuration.BrowserType);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Configuration.AppUrl);
            loginPage = new LoginPage(driver);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

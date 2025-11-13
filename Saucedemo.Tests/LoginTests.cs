using OpenQA.Selenium;
using Saucedemo.BLL;
using Saucedemo.CLL;

namespace Saucedemo.Tests
{
    public class LoginTests : IDisposable
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginTests()
        {
            driver = WebDriverSelector.CreateWebDriver(Configuration.BrowserType);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [Fact]
        public void ValidLogin_ShouldNavigateToInventoryPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage = new LoginPage(driver);
            loginPage.LoginAs("standard_user", "secret_sauce");

            Assert.Contains("inventory", driver.Url);
        }

        public void Dispose()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
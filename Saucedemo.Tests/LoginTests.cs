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
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Fact]
        public void EmptyCredentials_TriggersError_UsernameIsRequired()
        {
            loginPage = new LoginPage(driver);
            loginPage.TypeUsername("randomstring");
            loginPage.TypePassword("randomstring");
            Thread.Sleep(1000);
            loginPage.ClearInputs();
            loginPage.ClickLogin();
            Thread.Sleep(1000);
            string errorText = loginPage.GetErrorMessageText();
            Assert.Equal("Epic sadface: Username is required", errorText);
        }

        [Fact]
        public void EmptyPasswordInput_TriggersError_PasswordIsRequired()
        {
            loginPage = new LoginPage(driver);
            loginPage.LoginAs("username", "");
            Thread.Sleep(1000);
            string errorText = loginPage.GetErrorMessageText();
            Assert.Equal("Epic sadface: Password is required", errorText);
        }

        [Fact]
        public void ValidLogin_ShouldNavigateToInventoryPage()
        {
            loginPage = new LoginPage(driver);
            var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");

            Assert.Equal("Swag Labs", inventoryPage.GetTitleText());
        }

        public void Dispose()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
using OpenQA.Selenium;
using Saucedemo.BLL;
using Saucedemo.CLL;

namespace Saucedemo.Tests
{
    public class LoginTest1 : IDisposable
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginTest1()
        {
            driver = WebDriverSelector.CreateWebDriver(Configuration.BrowserType);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage = new LoginPage(driver);
        }

        [Fact]
        public void EmptyCredentials_TriggersError_UsernameIsRequired()
        {
            loginPage.TypeUsername("randomstring");
            loginPage.TypePassword("randomstring");
            Thread.Sleep(800);
            loginPage.ClearInputs();
            loginPage.ClickLogin();
            string errorText = loginPage.GetErrorMessageText();
            Assert.Equal("Epic sadface: Username is required", errorText);
        }

        public void Dispose()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
    public class LoginTest2 : IDisposable
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginTest2()
        {
            driver = WebDriverSelector.CreateWebDriver(Configuration.BrowserType);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage = new LoginPage(driver);
        }

        [Fact]
        public void EmptyPasswordInput_TriggersError_PasswordIsRequired()
        {
            loginPage.LoginAs("username", "");
            string errorText = loginPage.GetErrorMessageText();
            Assert.Equal("Epic sadface: Password is required", errorText);
        }

        public void Dispose()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
    public class LoginTest3 : IDisposable
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginTest3()
        {
            driver = WebDriverSelector.CreateWebDriver(Configuration.BrowserType);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage = new LoginPage(driver);
        }
         
        [Fact]
        public void ValidLogin_ShouldNavigateToInventoryPage()
        {
            var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");
            Assert.Equal("Swag Labs", inventoryPage.GetTitleText());
        }

        public void Dispose()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
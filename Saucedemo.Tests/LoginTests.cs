using OpenQA.Selenium;
using Saucedemo.BLL;
using Saucedemo.CLL;
using FluentAssertions;

namespace Saucedemo.Tests
{
    public class LoginTest1 : BaseTest
    {
        [Fact]
        public void EmptyCredentials_TriggersError_UsernameIsRequired()
        {
            log.Info("Running test: EmptyCredentials_TriggersError_UsernameIsRequired");
            loginPage.TypeUsername("randomstring");
            loginPage.TypePassword("randomstring");
            log.Info("Entered temporary credentials to ensure fields are active.");
            loginPage.ClearInputs();
            log.Info("Cleared input fields.");
            loginPage.ClickLogin();
            log.Info("Clicked login button with empty credentials.");
            string errorText = loginPage.GetErrorMessageText();
            log.Info($"Captured error message: '{errorText}'");
            errorText.Should().Be("Epic sadface: Username is required");
            Assert.Equal("Epic sadface: Username is required", errorText);
            log.Info("Assertion passed: Username required message displayed correctly.");
        }
    }

    public class LoginTest2 : BaseTest
    {
        [Fact]
        public void EmptyPasswordInput_TriggersError_PasswordIsRequired()
        {
            log.Info("Running test: EmptyPasswordInput_TriggersError_PasswordIsRequired");
            loginPage.LoginAs("username", "");
            log.Info("Attempted login with username but empty password.");
            string errorText = loginPage.GetErrorMessageText();
            log.Info($"Captured error message: '{errorText}'");
            errorText.Should().Be("Epic sadface: Password is required");
            log.Info("Assertion passed: Password required message displayed correctly.");
        }
    }

    public class LoginTest3 : BaseTest
    {
        [Fact]
        public void ValidLogin_ShouldNavigateToInventoryPage()
        {
            log.Info("Running test: ValidLogin_ShouldNavigateToInventoryPage");
            var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");
            log.Info("Logged in using valid credentials.");
            string title = inventoryPage.GetTitleText();
            log.Info($"Inventory page title: '{title}'");
            title.Should().Be("Swag Labs");
           log.Info("Assertion passed: Navigated successfully to the Inventory page.");
        }
    }
}
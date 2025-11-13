using OpenQA.Selenium;
using Saucedemo.BLL;
using Saucedemo.CLL;
using FluentAssertions;
using Xunit;

namespace Saucedemo.Tests
{
    public class DataProvidedLoginTests : BaseTest
    {
        [Theory]
        [MemberData(nameof(LoginData), MemberType = typeof(BaseTest))]
        public void LoginTests_Parametrized(string username, string password, string expected)
        {
            log.Info($"Running login test with Username: '{username}', Password: '{password}'");

            if (expected == "inventory")
            {
                var inventoryPage = loginPage.LoginAs(username, password);
                string title = inventoryPage.GetTitleText();
                log.Info($"Inventory page title: '{title}'");
                title.Should().Be("Swag Labs");
            }
            else
            {
                loginPage.LoginAs(username, password);
                string errorText = loginPage.GetErrorMessageText();
                log.Info($"Captured error message: '{errorText}'");
                errorText.Should().Be(expected);
            }

            log.Info("Test finished.");
        }
    }
}

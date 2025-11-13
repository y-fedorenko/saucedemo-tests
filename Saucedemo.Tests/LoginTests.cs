using OpenQA.Selenium;
using Saucedemo.BLL;
using Saucedemo.CLL;

namespace Saucedemo.Tests
{
    public class LoginTest1 : BaseTest
    {
        [Fact]
        public void EmptyCredentials_TriggersError_UsernameIsRequired()
        {
            loginPage.TypeUsername("randomstring");
            loginPage.TypePassword("randomstring");
            loginPage.ClearInputs();
            loginPage.ClickLogin();
            string errorText = loginPage.GetErrorMessageText();
            Assert.Equal("Epic sadface: Username is required", errorText);
        }
    }

    public class LoginTest2 : BaseTest
    {
        [Fact]
        public void EmptyPasswordInput_TriggersError_PasswordIsRequired()
        {
            loginPage.LoginAs("username", "");
            string errorText = loginPage.GetErrorMessageText();
            Assert.Equal("Epic sadface: Password is required", errorText);
        }
    }

    public class LoginTest3 : BaseTest
    {
        [Fact]
        public void ValidLogin_ShouldNavigateToInventoryPage()
        {
            var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");
            Assert.Equal("Swag Labs", inventoryPage.GetTitleText());
        }
    }
}
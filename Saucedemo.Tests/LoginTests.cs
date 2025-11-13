using OpenQA.Selenium;
using Saucedemo.CLL;

namespace Saucedemo.Tests
{
    public class LoginTests
    {
        private LoginPage _loginPage;
        //IWebDriver driver = WebDriverSelector.CreateWebDriver("FireFox");

        public LoginTests()
        {
            _loginPage = new LoginPage();
        }
        [Fact]
        public void Test1()
        {

        }

        public void Dispose()
        {

        }
    }
}
using OpenQA.Selenium;

namespace Saucedemo.BLL
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UsernameInputText => _driver.FindElement(By.CssSelector("#user-name"));
        private IWebElement PasswordInputText => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginInputSubmit => _driver.FindElement(By.CssSelector("#login-button"));

        public void TypeUsername(string input) 
        { 
            UsernameInputText.Clear();
            UsernameInputText.SendKeys(input);
        }

        public void TypePassword(string input) 
        {
            PasswordInputText.Clear();
            PasswordInputText.SendKeys(input);
        }

        public void ClickLogin()
        {
            LoginInputSubmit.Click();
        }

    }
}

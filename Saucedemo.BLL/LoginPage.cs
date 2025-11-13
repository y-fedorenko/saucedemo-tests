using OpenQA.Selenium;

namespace Saucedemo.BLL
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            //driver.Navigate().GoToUrl("www.saucedemo.com");
        }

        private IWebElement UsernameInputText => _driver.FindElement(By.CssSelector("#user-name"));
        private IWebElement PasswordInputText => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginInputSubmit => _driver.FindElement(By.CssSelector("#login-button"));

        private void TypeUsername(string input) 
        { 
            UsernameInputText.Clear();
            UsernameInputText.SendKeys(input);
        }

        private void TypePassword(string input) 
        {
            PasswordInputText.Clear();
            PasswordInputText.SendKeys(input);
        }

        private void ClickLogin()
        {
            LoginInputSubmit.Click();
        }
        public void LoginAs(string username, string password)
        {
            TypeUsername(username);
            TypePassword(password);
            ClickLogin();
        }
    }
}

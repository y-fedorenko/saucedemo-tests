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
        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("[data-test='error']"));


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
        public InventoryPage LoginAs(string username, string password)
        {
            TypeUsername(username);
            TypePassword(password);
            ClickLogin();

            return new InventoryPage(_driver);
        }

        public void ClearInputs()
        {
            UsernameInputText.SendKeys(Keys.Control + "a");
            UsernameInputText.SendKeys(Keys.Delete);
            PasswordInputText.SendKeys(Keys.Control + "a");
            PasswordInputText.SendKeys(Keys.Delete);
            Thread.Sleep(500);
        }

        public string GetErrorMessageText()
        {
            return ErrorMessage.Text;
        }
    }
}

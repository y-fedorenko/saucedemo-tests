using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Saucedemo.CLL
{
    public class WebDriverSelector
    {
        public static IWebDriver CreateWebDriver(string input)
        {
            switch (input.ToLower())
            {
                case "edge":
                    return new EdgeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "chrome":
                default:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var options = new ChromeOptions();

                        options.AddArgument("--disable-infobars");
                        options.AddArgument("--incognito");
                        options.AddArgument("--disable-autofill");
                        options.AddArgument("--disable-password-generation");
                        options.AddArgument("--disable-save-password-bubble");
                        options.AddUserProfilePreference("autofill.profile_enabled", false);
                        options.AddUserProfilePreference("autofill.credit_card_enabled", false);
                        options.AddUserProfilePreference("autofill.address_enabled", false);
                        options.AddUserProfilePreference("credentials_enable_service", false);
                        options.AddUserProfilePreference("profile.password_manager_enabled", false);
                        var driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(30));
                        driver.Manage().Window.Maximize();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                        return driver;
                    }
            }
        }
    }
}

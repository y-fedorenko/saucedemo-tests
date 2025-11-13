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
                        ChromeOptions options = new();
                        options.AddArgument("disable-infobars");
                        options.AddArgument("--incognito");

                        return new ChromeDriver(service, options, TimeSpan.FromSeconds(30));
                    }
            }
        }
    }
}

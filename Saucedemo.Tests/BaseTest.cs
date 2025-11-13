using OpenQA.Selenium;
using Saucedemo.BLL;
using Saucedemo.CLL;
using log4net;
using log4net.Config;
using System.Reflection;

namespace Saucedemo.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod()!.DeclaringType);
        protected IWebDriver driver;
        protected LoginPage loginPage;

        public static IEnumerable<object[]> LoginData =>
            new List<object[]>
            {
                new object[] { "standard_user", "secret_sauce", "inventory" },
                new object[] { "", "secret_sauce", "Epic sadface: Username is required" },
                new object[] { "standard_user", "", "Epic sadface: Password is required" }
            };

        protected BaseTest()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            log.Info("========= TEST START =========");
            log.Info($"Initializing WebDriver for browser: {Configuration.BrowserType}");
            driver = WebDriverSelector.CreateWebDriver(Configuration.BrowserType);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            log.Info($"Navigating to application: {Configuration.AppUrl}");
            driver.Navigate().GoToUrl(Configuration.AppUrl);
            loginPage = new LoginPage(driver);
        }

        public void Dispose()
        {
            log.Info("Disposing WebDriver...");
            driver.Quit();
            log.Info("========= TEST END =========\n");
        }
    }
}

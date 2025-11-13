using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.BLL
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement AppLogo => _driver.FindElement(By.CssSelector("div.app_logo"));

        public string GetTitleText()
        {
            return AppLogo.Text;
        }
    }
}

using OpenQA.Selenium;

namespace SeleniumHomeTaskV4_2.PageObjects
{
    internal class DashboardPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _adminMenuItemLocator = By.CssSelector(".oxd-main-menu-item");

        public DashboardPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SystemUsersPageObject GoToAdminPanel()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _adminMenuItemLocator);
            _webDriver.FindElement(_adminMenuItemLocator).Click();

            return new SystemUsersPageObject(_webDriver);
        }
    }
}

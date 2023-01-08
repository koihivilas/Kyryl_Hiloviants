using OpenQA.Selenium;

namespace SeleniumHomeTaskV4_2.PageObjects
{
    internal class ConfirmationModalPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _confirmButtonLocator = By.XPath("//div[3]/button[2]");

        public ConfirmationModalPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public WorkShiftsPageObject Confirm()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _confirmButtonLocator);
            _webDriver.FindElement(_confirmButtonLocator).Click();

            return new WorkShiftsPageObject(_webDriver);
        }

    }
}

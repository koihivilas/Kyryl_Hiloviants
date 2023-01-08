using OpenQA.Selenium;

namespace SeleniumHomeTaskV4_2.PageObjects
{
    internal class SystemUsersPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _jobsDropdownLocator = By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]");
        private readonly By _workShiftsLocator = By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]/ul/li[5]/a");

        public SystemUsersPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public WorkShiftsPageObject GoToWorkShiftsPage()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _jobsDropdownLocator);
            _webDriver.FindElement(_jobsDropdownLocator).Click();

            Delays.WaitUntilElementIsLoaded(_webDriver, _workShiftsLocator);
            _webDriver.FindElement(_workShiftsLocator).Click();

            return new WorkShiftsPageObject(_webDriver);
        }
    }
}

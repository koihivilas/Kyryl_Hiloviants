using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHomeTaskV4_2.PageObjects
{
    internal class WorkShiftsPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _addWorkShiftButtonLocator = By.CssSelector(".oxd-button");
        private string _shiftName = "RandomName";
        private readonly By _newRowLocator = By.XPath("//div[contains(@class, 'oxd-table-row') and contains(., 'RandomName')]");
        private readonly By _newRowCheckboxLocator = By.XPath("//div[contains(@class, 'oxd-table-row') and contains(., 'RandomName')]//i[contains(@class,'bi-check')]");
        private readonly By _deleteSelectedButtonLocator = By.CssSelector(".oxd-button--label-danger");
        private readonly By _workShiftsTableLocator = By.CssSelector(".oxd-table");
        private readonly By _recordsNumberTextLocator = By.XPath("//div[2]/div/span");

        public WorkShiftsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SaveWorkShiftsPageObject AddWorkShift()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _addWorkShiftButtonLocator);
            _webDriver.FindElement(_addWorkShiftButtonLocator).Click();

            return new SaveWorkShiftsPageObject(_webDriver);
        }

        public void CheckNewRow()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _newRowLocator);
            var newRow = _webDriver.FindElement(_newRowLocator);

            Assert.NotZero(newRow.FindElements(By.XPath($"//div[contains(., '{_shiftName}')]")).Count);
            Assert.NotZero(newRow.FindElements(By.XPath($"//div[contains(., '06:00')]")).Count);
            Assert.NotZero(newRow.FindElements(By.XPath($"//div[contains(., '18:00')]")).Count);
            Assert.NotZero(newRow.FindElements(By.XPath($"//div[contains(., '12.00')]")).Count);
        }

        public void SelectNewRow()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _recordsNumberTextLocator);
            _webDriver.FindElement(_newRowCheckboxLocator).Click();
        }

        public ConfirmationModalPageObject DeleteSelectedRows()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _deleteSelectedButtonLocator);
            _webDriver.FindElement(_deleteSelectedButtonLocator).Click();

            return new ConfirmationModalPageObject(_webDriver);
        }

        public void CheckDeletedRow()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _recordsNumberTextLocator);
            Assert.Zero(_webDriver.FindElements(_newRowLocator).Count);
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHomeTaskV4_2.PageObjects
{
    internal class SaveWorkShiftsPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _shiftNameInputLocator = By.XPath("//input[not(@placeholder)]");
        private string _shiftName = "RandomName";
        private string _assignedEmployee = "Odis Adalwin";
        private readonly By _timeInputsLocator = By.CssSelector(".oxd-time-wrapper");
        private readonly By _timeHourDownButtonLocator = By.CssSelector(".oxd-time-hour-input-down");
        private readonly By _timeHourUpButtonLocator = By.CssSelector(".oxd-time-hour-input-up");
        private readonly By _assignedEmployeesInputLocator = By.CssSelector(".oxd-autocomplete-text-input input");
        private readonly By _saveButtonLocator = By.CssSelector("[type='submit']");


        public SaveWorkShiftsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void EnterShiftName()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _shiftNameInputLocator);
            _webDriver.FindElement(_shiftNameInputLocator).SendKeys(_shiftName);
        }

        public void SetFromTime()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _timeInputsLocator);
            var timeFromInput = _webDriver.FindElements(_timeInputsLocator)[0];
            timeFromInput.Click();

            Delays.WaitUntilElementIsLoaded(_webDriver, _timeHourDownButtonLocator);
            var timeHourDownButton = _webDriver.FindElement(_timeHourDownButtonLocator);
            for (int i = 0; i < 3; i++)
            {
                timeHourDownButton.Click();
            }
        }

        public void SetToTime()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _timeInputsLocator);
            var timeToInput = _webDriver.FindElements(_timeInputsLocator)[1];
            timeToInput.Click();

            _webDriver.FindElement(_timeHourUpButtonLocator).Click();
        }

        public void AssignEmployee()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _assignedEmployeesInputLocator);
            _webDriver.FindElement(_assignedEmployeesInputLocator).SendKeys(_assignedEmployee);
        }

        public WorkShiftsPageObject SaveWorkShift()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _saveButtonLocator);
            _webDriver.FindElement(_saveButtonLocator).Click();

            return new WorkShiftsPageObject(_webDriver);
        }
    }
}

using OpenQA.Selenium;

namespace SeleniumHomeTaskV4_2.PageObjects
{
    internal class LoginPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _loginCredentialsLocator = By.CssSelector(".oxd-sheet p.oxd-text");
        private readonly By _usernameInputLocator = By.CssSelector("input[name='username']");
        private readonly By _passwordInputLocator = By.CssSelector("input[name='password']");
        private readonly By _loginButtonLocator = By.CssSelector(".oxd-button");

        public LoginPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void EnterUsername()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _loginCredentialsLocator);
            var username = _webDriver.FindElements(_loginCredentialsLocator)[0].Text.Split(' ')[2];
            Delays.WaitUntilElementIsLoaded(_webDriver, _usernameInputLocator);
            var usernameInput = _webDriver.FindElement(_usernameInputLocator);

            usernameInput.SendKeys(username);
        }

        public void EnterPassword()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _loginCredentialsLocator);
            var password = _webDriver.FindElements(_loginCredentialsLocator)[1].Text.Split(' ')[2];
            Delays.WaitUntilElementIsLoaded(_webDriver, _passwordInputLocator);
            var passwordInput = _webDriver.FindElement(_passwordInputLocator);

            passwordInput.SendKeys(password);
        }

        public DashboardPageObject Login()
        {
            Delays.WaitUntilElementIsLoaded(_webDriver, _loginButtonLocator);
            _webDriver.FindElement(_loginButtonLocator).Click();

            return new DashboardPageObject(_webDriver);
        }

    }
}

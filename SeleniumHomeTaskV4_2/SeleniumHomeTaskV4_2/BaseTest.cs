using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumHomeTaskV4_2
{
    public class BaseTest
    {
        protected IWebDriver _webDriver;

        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            _webDriver = new ChromeDriver();
        }


        [SetUp]
        protected void DoBeforeEach()
        {
            _webDriver.Navigate().GoToUrl(TestSettings.Url);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void DoAfterEach() {
            _webDriver.Quit();
        }
    }
}

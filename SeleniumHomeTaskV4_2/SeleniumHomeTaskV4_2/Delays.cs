using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumHomeTaskV4_2
{
    public static class Delays
    {
        public static void WaitUntilElementIsLoaded(IWebDriver webDriver, By locator)
        {
            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(e =>
            {
                try
                {
                    return e.FindElement(locator).Displayed;
                } catch { 
                    return false; 
                }
            });
        }

        public static void WaitSomeTime(int milliseconds = 500)
        {
            Task.Delay(TimeSpan.FromMilliseconds(milliseconds)).Wait();
        }
    }
}

using OpenQA.Selenium;

namespace JQSelenium
{
    public class JQueryFactory
    {
        readonly IWebDriver _driver;

        public JQueryFactory(IWebDriver driver)
        {
            _driver = driver;
        }

        public IJQuerySelector Query(string selector)
        {
            return null;
        }
    }
}
using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    public class when_getting_a_tag
    {
        static JQueryFactory _jquery;
        static JQueryTag _result;
        static JQueryTag _expectedTag;

        Establish context = () =>
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://api.jquery.com/find/");
                _jquery = new JQueryFactory(driver);

                _expectedTag = new JQueryTag
                    {
                        _tagName = "body"
                    };
                _expectedTag._webElement = (IWebElement) driver.FindElementByTagName("body");
                _expectedTag._selector = "jQuery.find('body')[0]";

            };

        Because of = () => _result = _jquery.Query("body").Get();

        It should_return_the_expected_tag = () => _result.IsExpectedToBeLike(_expectedTag);

        Cleanup loaded_context = () => driver.Close();
        static FirefoxDriver driver;
    }
}
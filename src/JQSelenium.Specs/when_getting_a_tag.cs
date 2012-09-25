using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    public class when_getting_a_tag
    {
        static JQueryFactory _jquery;
        static IJQueryTag _result;
        static JQueryTag _expectedTag;

        Establish context = () =>
            {
                var driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://api.jquery.com/find/");
                _jquery = new JQueryFactory(driver);

                _expectedTag = new JQueryTag
                    {
                        tagName = "body"
                    };
                _expectedTag.webElement = (IWebElement) driver.FindElementByTagName("body");
                _expectedTag.selector = "jQuery.find('body')[0]";

            };

        Because of = () => _result = _jquery.Query("body").Get();

        It should_return_the_expected_tag = () => _result.IsExpectedToBeLike(_expectedTag);
    }
}
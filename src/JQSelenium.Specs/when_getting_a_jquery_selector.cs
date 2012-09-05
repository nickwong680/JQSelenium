using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    public class when_getting_a_jquery_selector
    {
        static JQueryFactory _jquery;
        static IJQuerySelector _result;
        static IjQuerySelectorSelector _expectedJquerySelectorSelector;

        Establish context = () =>
            {
                var driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://www.google.com");

                _jquery = new JQueryFactory(driver);

                _expectedJquerySelectorSelector = new IjQuerySelectorSelector();
            };

        Because of = () => _result = _jquery.Query("body");

        It should_return_the_expected_tag = () => _result.IsExpectedToBeLike(_expectedJquerySelectorSelector);
    }
}
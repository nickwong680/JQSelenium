//using System.Windows.Forms;
using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    public class when_getting_a_jquery_selector
    {
        static JQueryFactory _jquery;
        static JQuerySelector _result;
        static JQuerySelector _expectedJquerySelectorSelector;

        Establish context = () =>
            {
                var driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://api.jquery.com/find/");

                _jquery = new JQueryFactory(driver);

                _expectedJquerySelectorSelector = _jquery.Query("body");
                _expectedJquerySelectorSelector.Get();
            };

        Because of = () =>  _result = _jquery.Query("body");

        It should_return_the_expected_tag = () => _result.IsExpectedToBeLike(_expectedJquerySelectorSelector);
    }
}
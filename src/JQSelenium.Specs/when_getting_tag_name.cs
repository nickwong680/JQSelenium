using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    public class when_getting_tag_name
    {
        static JQueryFactory _jquery;
        static string _result;

        Establish context = () =>
            {
                var driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://www.google.com");

                _jquery = new JQueryFactory(driver);
            };

        Because of = () => _result = _jquery.Query("body").Get().GetTagName();


        It should_return_the_tags_name = () => _result.ShouldEqual("body");
    }
}
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
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://api.jquery.com/find/");

                _jquery = new JQueryFactory(driver);
            };

        Because of = () => _result = _jquery.Query("body").Get().GetTagName();
        
        It should_return_the_tags_name = () => _result.ShouldEqual("body");

        Cleanup loaded_context = () => driver.Close();
        static FirefoxDriver driver;
    }
}
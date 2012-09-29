using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_adding_content_after_selector
    {
        static JQuerySelector _testingSelector;
        static string _newTag;
        static string _newText;
        static JQuerySelector _expectedSelector;
        static JQueryFactory _jqf;
        static FirefoxDriver _driver;

        Establish context = () =>
                                {
                                    _driver = new FirefoxDriver();
                                    _driver.Navigate().GoToUrl("http://api.jquery.com/find/");
                                    _jqf = new JQueryFactory(_driver);
                                    _testingSelector = _jqf.Query("h1");
                                    _newText = "Probando";
                                    _newTag = "<p id = \"jQ-selenium\">" + _newText + "</p>";
                                };

        Because of = () =>
                         {
                             _testingSelector.after(_newTag);
                             _expectedSelector = _jqf.Query("#jQ-selenium");
                         };

        It should_return_the_expected_tag = () => _expectedSelector.isEmpty().ShouldBeFalse();

        Cleanup when_finished = () => _driver.Close();
    }
}
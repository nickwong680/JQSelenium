using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_getting_html_of_element : given_a_jquery_factory_context
    {
        static JQuerySelector _jQuerySelector;
        static JQueryTag _jQueryTag;
        static string _expectedHtml;
        static object _resultingHtml;

        Establish load_context = () =>
            {
                _jQuerySelector = jQueryFactory.Query("h1");
                _jQueryTag = _jQuerySelector.Get();
                _expectedHtml = "jQuery API";
            };

        Because of = () => _resultingHtml = _jQueryTag.html();

        It should_return_its_html_content = () => _resultingHtml.ShouldEqual(_expectedHtml);
    }
}
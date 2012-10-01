using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_getting_a_css_property_from_an_element : given_a_jquery_factory_context
    {
        static string _expectedColor;
        static JQueryTag _testingTag;
        static string _result;

        Establish context = () =>
            {
                _expectedColor = "rgba(221, 221, 221, 1)";
                var testingSelector = jQueryFactory.Query("h1");
                _testingTag = testingSelector.Get();
            };

        Because of = () => _result = _testingTag.css("color");

        It should_return_the_tags_name = () => _result.ShouldEqual(_expectedColor);
    }
}
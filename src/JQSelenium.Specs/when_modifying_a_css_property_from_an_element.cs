using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_modifying_a_css_property_from_an_element : given_a_jquery_factory_context
    {
        static string _newColor;
        static string _result;
        static JQuerySelector _testingSelector;

        Establish context = () =>
            {
                _newColor = "rgba(0, 1, 1, 1)";
                _testingSelector = JQuery.Find("h1");
            };

        Because of = () =>
            {
                _testingSelector = _testingSelector.Css("color", _newColor);
                _result = _testingSelector.Get().Css("color");
            };

        It should_have_the_attribute_modified = () => _result.ShouldEqual(_newColor);
    }
}
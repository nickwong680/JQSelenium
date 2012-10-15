using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_modifying_an_attribute_from_an_element : given_a_jquery_factory_context
    {
        static string _expectedClassName;
        static string _result;
        static JQuerySelector _testingSelector;

        Establish context = () =>
            {
                _expectedClassName = "testing_class";
                _testingSelector = JQuery.Find("h1");
                _testingSelector = _testingSelector.AddClass("InitialClassName");
            };

        Because of = () =>
            {
                _testingSelector = _testingSelector.Attr("class", _expectedClassName);
                _result = _testingSelector.Get().Attr("class");
            };

        It should_have_the_attribute_modified = () => _result.ShouldEqual(_expectedClassName);
    }
}
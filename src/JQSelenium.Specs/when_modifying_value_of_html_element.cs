using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_modifying_value_of_html_element : given_a_jquery_factory_context
    {
        static JQueryTag _jQueryTag;
        static string _expectedValue;
        static string _resultingValue;

        Establish context = () =>
            {
                var jqs = JQuery.Find("#jq-primarySearch");
                _expectedValue = "TestString";
                _jQueryTag = jqs.Get();
            };

        Because of = () => _jQueryTag.Val(_expectedValue);

        It should_return_value = () => _jQueryTag.Val().ShouldEqual(_expectedValue);
    }
}
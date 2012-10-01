using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_getting_value_of_element : given_a_jquery_factory_context
    {
        static JQueryTag _jQueryTag;
        static string _expectedValue;
        static string _resultingValue;

        Establish context = () =>
            {
                JQuerySelector jqs = jQueryFactory.Query("#jq-primarySearch");
                _expectedValue = "TestString";
                _jQueryTag = jqs.Get();
                _jQueryTag.WebElement.SendKeys(_expectedValue);
            };

        Because of = () => _resultingValue = _jQueryTag.val();

        It should_return_value = () => _resultingValue.ShouldEqual(_expectedValue);
    }
}
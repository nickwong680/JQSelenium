using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_obtaining_all_the_previous_elements_of_an_element : given_a_jquery_factory_context
    {
        static JQuerySelector _expectedSelector;
        static JQuerySelector _testSelector;
        static JQuerySelector _result;

        Establish context = () =>
            {
                _testSelector = jQueryFactory.Query("#jq-primaryNavigation");
                _expectedSelector = jQueryFactory.Query("#jq-siteLogo");
            };

        Because of = () => _result = _testSelector.prevAll();

        It should_return_all_the_expected_elements = () => _result.hasSameElementsOf(_expectedSelector).ShouldBeTrue();
    }
}
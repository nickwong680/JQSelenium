using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_obtaining_all_the_next_elements_of_an_element : given_a_jquery_factory_context
    {
        static JQuerySelector _expectedSelector;
        static JQuerySelector _testSelector;
        static JQuerySelector _result;

        Establish context = () =>
            {
                _testSelector = jQueryFactory.Query("#jq-secondaryNavigation");
                _expectedSelector = jQueryFactory.Query("#jq-primarySearchForm");
                _expectedSelector.add("$('h1')[0]");
            };

        Because of = () => _result = _testSelector.nextAll();

        It should_return_all_the_expected_elements = () => _result.hasSameElementsOf(_expectedSelector).ShouldBeTrue();
    }
}
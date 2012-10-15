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
                _testSelector = JQuery.Find("#jq-secondaryNavigation");
                _expectedSelector = JQuery.Find("#jq-primarySearchForm");
                _expectedSelector.Add("$('h1')[0]");
            };

        Because of = () => _result = _testSelector.NextAll();

        It should_return_all_the_expected_elements = () => _result.HasSameElementsOf(_expectedSelector).ShouldBeTrue();
    }
}
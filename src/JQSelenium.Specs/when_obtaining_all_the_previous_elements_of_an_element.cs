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
                _testSelector = JQuery.Find("#jq-primaryNavigation");
                _expectedSelector = JQuery.Find("#jq-siteLogo");
            };

        Because of = () => _result = _testSelector.PrevAll();

        It should_return_all_the_expected_elements = () => _result.HasSameElementsOf(_expectedSelector).ShouldBeTrue();
    }
}
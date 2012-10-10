using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_getting_first_element_of_selector : given_a_jquery_factory_context
    {
        static JQuerySelector _selector;
        static string _expectedResult;
        static JQueryTag _result;

        Establish context = () =>
            {
                _selector = jQueryFactory.Query("h1");
                _expectedResult = "JQUERY API";
            };

        Because of = () => _result = _selector.first();

        It should_return_first_element = () => _result.text().ShouldBeEqualIgnoringCase(_expectedResult);

        Cleanup when_finished = () => { };
    }
}
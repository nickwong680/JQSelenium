using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_obtaining_element_next_to_element : given_a_jquery_factory_context
    {
        static JQuerySelector _selector;
        static string _expectedResult;
        static JQuerySelector _result;

        Establish context = () =>
            {
                _selector = jQueryFactory.Query("h3");
                _expectedResult = "entry-examples";
            };

        Because of = () => _result = _selector.next();

        It should_return_adjacent_element = () => _result.Get().attr("id").ShouldEqual(_expectedResult);
    }
}
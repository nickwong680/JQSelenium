using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_obtaining_parent_of_element : given_a_jquery_factory_context
    {
        static JQuerySelector _selector;
        static string _expectedResult;
        static JQuerySelector _result;

        Establish context = () =>
            {
                _selector = jQueryFactory.Query("h1");
                _expectedResult = "jq-header";
            };

        Because of = () => _result = _selector.parent();

        It should_return_parent_element = () => _result.Get().attr("id").ShouldEqual(_expectedResult);
    }
}
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
                _selector = JQuery.Find("h3");
                _expectedResult = "entry-examples";
            };

        Because of = () => _result = _selector.Next();

        It should_return_adjacent_element = () => _result.Get().Attr("id").ShouldEqual(_expectedResult);
    }
}
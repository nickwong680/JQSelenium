using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_obtaining_element_previous_to_element : given_a_jquery_factory_context
    {
        static JQuerySelector _selector;
        static string _expectedResult;
        static JQuerySelector _result;

        Establish context = () =>
            {
                _selector = JQuery.Find("h1");
                _expectedResult = "jq-primarySearchForm";
            };

        Because of = () => _result = _selector.Prev();

        It should_return_adjacent_element = () => _result.Get().Attr("id").ShouldEqual(_expectedResult);
    }
}
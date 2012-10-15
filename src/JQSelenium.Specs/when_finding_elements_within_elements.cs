using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_finding_elements_within_elements : given_a_jquery_factory_context
    {
        Establish context = () =>
            {
                _selector = JQuery.Find(".entry-title");
                _expectedResult = ".find()";
            };

        Because of = () => _result = _selector.Find("h1");

        It should_return_the_child_element = () => _result.Get().Text().ShouldEqual(_expectedResult);

        Cleanup when_finished = () => { };

        static JQuerySelector _selector;
        static string _expectedResult;
        static JQuerySelector _result;
    }
}
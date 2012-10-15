using System;
using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_getting_last_element_of_selector : given_a_jquery_factory_context
    {
        static JQuerySelector _selector;
        static string _expectedResult;
        static JQueryTag _result;

        Establish context = () =>
            {
                _selector = JQuery.Find("h1");
                _expectedResult = "Support and Contributions";
            };

        Because of = () => _result = _selector.Last();

        It should_return_last_element = () => _result.Text().ShouldEqual(_expectedResult);

        Cleanup when_finished = () => { };
    }
}
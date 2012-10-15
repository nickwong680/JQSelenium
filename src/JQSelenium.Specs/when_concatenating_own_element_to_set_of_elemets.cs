using System;
using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_concatenating_own_element_to_set_of_elemets : given_a_jquery_factory_context
    {
        static JQuerySelector _selector;
        static JQuerySelector _result;
        static string _expectedNextResult;
        static string _expectedResult;

        Establish context = () =>
            {
                _selector = JQuery.Find("h3");
                _expectedNextResult = "entry-examples";
                _expectedResult = "Examples:";
            };

        Because of = () => _result = _selector.Next().AndSelf();

        It should_include_next_element = () => _result.Get(0).Text().ShouldEqual(_expectedResult);

        It should_include_own_element = () => _result.Get(1).Attr("id").ShouldEqual(_expectedNextResult);
    }
}
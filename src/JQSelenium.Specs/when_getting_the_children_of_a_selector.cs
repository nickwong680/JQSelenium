using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_getting_the_children_of_a_selector : given_a_jquery_factory_context
    {
        static JQuerySelector _contextSelector;
        static JQuerySelector _expectedChildren;
        static JQuerySelector _result;

        Establish context = () =>
            {
                _contextSelector = JQuery.Find("div#jq-primaryNavigation");
                _expectedChildren = new JQuerySelector(JQuery.Find("ul").First().Get());
            };

        Because of = () => { _result = _contextSelector.Children(); };

        It should_return_all_its_children = () => _result.HasSameElementsOf(_expectedChildren).ShouldBeTrue();
    }
}
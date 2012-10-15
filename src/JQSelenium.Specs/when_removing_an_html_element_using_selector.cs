using Machine.Specifications;

namespace JQSelenium.Specs
{
    class when_removing_an_html_element_using_selector : given_a_jquery_factory_context
    {
        static JQuerySelector _jQuerySelector;
        Establish context = () => { _jQuerySelector = JQuery.Find("div"); };

        Because of = () => _jQuerySelector.Remove("#jq-header");

        It should_remove_html_element = () => JQuery.Find("#jq-header").ShouldBeEmpty();
    }
}
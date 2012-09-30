using Machine.Specifications;

namespace JQSelenium.Specs
{
    class when_removing_an_html_element_using_selector : given_a_jquery_factory_context
    {
        static JQuerySelector _jQuerySelector;
        Establish context = () => { _jQuerySelector = jQueryFactory.Query("div"); };

        Because of = () => _jQuerySelector.remove("#jq-header");

        It should_remove_html_element = () => jQueryFactory.Query("#jq-header").ShouldBeEmpty();
    }
}
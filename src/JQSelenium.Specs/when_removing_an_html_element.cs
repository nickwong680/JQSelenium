using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_removing_an_html_element : given_a_jquery_factory_context
    {
        static JQuerySelector _jQuerySelector;

        Establish context = () => { _jQuerySelector = JQuery.Find("h1"); };

        Because of = () => _jQuerySelector.Remove();

        It should_remove_html_elements = () => JQuery.Find("h1").ShouldBeEmpty();
    }
}
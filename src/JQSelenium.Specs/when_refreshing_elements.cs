using System;
using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_refreshing_elements : given_a_jquery_factory_context
    {
        static int _originalValue;
        static JQuerySelector _selector;

        Establish context = () =>
            {
                _selector = JQuery.Find("h1:contains('contains')");
                _originalValue = _selector.Count();
                Driver.Navigate().GoToUrl("http://api.jquery.com/contains-selector/");
            };

        Because of = () => _selector.RefreshElements();

        It should_update_set_of_elements = () => _selector.Count().ShouldNotEqual(_originalValue);

        Cleanup when_finished = () => { };
    }
}
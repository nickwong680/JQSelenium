using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_removing_an_specific_class : given_a_jquery_factory_context
    {
        static string _className;
        static JQuerySelector _jQuerySelector;
        static object _result;
        static string _newClassName;

        Establish context = () =>
            {
                _newClassName = "randomClass";
                _className = "jq-clearfix";
                _jQuerySelector = JQuery.Find("." + _className);
                _jQuerySelector.AddClass(_newClassName);
            };

        Because of = () => _jQuerySelector.RemoveClass(_className);

        It should_have_only_one_class_name = () => _jQuerySelector.HasClass(_newClassName).ShouldBeTrue();

        It should_remove_the_class = () => _jQuerySelector.HasClass(_className).ShouldBeFalse();
    }
}
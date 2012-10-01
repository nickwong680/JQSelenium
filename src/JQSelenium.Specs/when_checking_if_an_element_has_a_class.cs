using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_checking_if_an_element_has_a_class : given_a_jquery_factory_context
    {
        static JQuerySelector _testingSelector;
        static string _testingClass;
        static bool _hasClass;

        Establish context = () =>
            {
                _testingClass = "new_Class";
                _testingSelector = jQueryFactory.Query("h1").addClass(_testingClass);
            };

        Because of = () => _hasClass = _testingSelector.hasClass(_testingClass);

        It should_return_the_modified_element = () => _hasClass.ShouldBeTrue();
    }
}
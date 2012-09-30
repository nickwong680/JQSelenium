//using System.Windows.Forms;

using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_getting_a_jquery_selector : given_a_jquery_factory_context
    {
        static JQueryFactory _jquery;
        static JQuerySelector _result;
        static JQuerySelector _expectedJquerySelectorSelector;

        Establish context = () =>
            {
                _expectedJquerySelectorSelector = _jquery.Query("body");
                _expectedJquerySelectorSelector.Get();
            };

        Because of = () => _result = _jquery.Query("body");

        It should_return_the_expected_tag = () => _result.IsExpectedToBeLike(_expectedJquerySelectorSelector);
    }
}
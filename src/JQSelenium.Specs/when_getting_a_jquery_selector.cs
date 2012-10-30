//using System.Windows.Forms;

using System.Linq;
using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_getting_a_jquery_selector : given_a_jquery_factory_context
    {
        static JQuerySelector _result;
        
        Because of = () => _result = JQuery.Find("body");

        It should_return_the_expected_tag = () => _result.First().Get().TagName.ShouldEqual("body");
    }
}
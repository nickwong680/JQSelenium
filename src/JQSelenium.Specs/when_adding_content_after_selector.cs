using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_adding_content_after_selector : given_a_jquery_factory_context
    {
        static JQuerySelector _testingSelector;
        static string _newTag;
        static string _newText;
        static JQuerySelector _expectedSelector;

        Establish context = () =>
            {
                _testingSelector = JQuery.Find("h1");
                _newText = "Probando";
                _newTag = "<p id = \"jQ-selenium\">" + _newText + "</p>";
            };

        Because of = () =>
            {
                _testingSelector.After(_newTag);
                _expectedSelector = JQuery.Find("#jQ-selenium");
            };

        It should_return_the_expected_tag = () => _expectedSelector.IsEmpty().ShouldBeFalse();

        Cleanup when_finished = () => Driver.Close();
    }
}
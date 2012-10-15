using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_adding_content_before_selector : given_a_jquery_factory_context
    {
        static string _newText;
        static string _newTag;
        static JQuerySelector _testingSelector;
        static JQuerySelector _expectedSelector;

        Establish context = () =>
                                {
                                    _testingSelector = JQuery.Find("h1");
                                    _newText = "Probando";
                                    _newTag = "<p id = \"jQ-selenium\">" + _newText + "</p>";                                    
                                };

        Because of = () => _testingSelector.Before(_newTag);

        It should_return_the_expected_tag = () => JQuery.Find("#jQ-selenium").IsEmpty().ShouldBeFalse();
    }
}
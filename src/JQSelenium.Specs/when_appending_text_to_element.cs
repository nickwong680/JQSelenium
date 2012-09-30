using System;
using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_appending_text_to_element : given_a_jquery_factory_context
    {
        static JQueryTag _testingElement;
        static String _initialText;
        static String _finalText;
        static String _appendingText;
        static String _textExpected;
        static JQuerySelector _expectedJquerySelectorSelector;

        Establish context = () =>
            {
                _expectedJquerySelectorSelector = jQueryFactory.Query("h1");
                _testingElement = _expectedJquerySelectorSelector.Get();
                _initialText = _testingElement.text();
                _appendingText = " Aw yeah";
            };

        Because of = () =>
            {
                _testingElement.append(_appendingText);
                _textExpected = (_initialText + _appendingText).ToUpper();
            };

        It should_have_the_expected_text = () => _testingElement.text().ShouldEqual(_textExpected);
    }
}
using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;
using OpenQA.Selenium;

namespace JQSelenium.Specs
{
    public class when_getting_a_tag : given_a_jquery_factory_context
    {
        static JQueryTag _result;
        static JQuerySelector _selector;
        static string _expectedResult;

        Establish context = () =>
            {
                _expectedResult = "body";
                _selector = JQuery.Find("body");
            };

        Because of = () => _result = _selector.Get();

        It should_return_the_expected_tag = () => _result.TagName.ShouldEqual(_expectedResult);
    }
}
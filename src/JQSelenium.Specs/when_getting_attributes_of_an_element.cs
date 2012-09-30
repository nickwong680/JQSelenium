using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_getting_attributes_of_an_element : given_a_jquery_factory_context
    {
        static string _expectedClassName;
        static JQueryTag _testingTag;
        static string _result;

        Establish context = () =>
            {
                _expectedClassName = "testing_class";
                var testingSelector = jQueryFactory.Query("h1");
                testingSelector = testingSelector.addClass(_expectedClassName);
                _testingTag = testingSelector.Get();
            };

        Because of = () => _result = _testingTag.attr("class");

        It should_return_the_tags_name = () => _result.ShouldEqual(_expectedClassName);
    }
}
using Machine.Specifications;

namespace JQSelenium.Specs
{
    public class when_getting_tag_name : given_a_jquery_factory_context
    {
        static string _result;

        Because of = () => _result = JQuery.Find("body").Get().GetTagName();

        It should_return_the_tags_name = () => _result.ShouldEqual("body");
    }
}
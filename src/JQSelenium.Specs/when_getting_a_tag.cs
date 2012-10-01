using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;
using OpenQA.Selenium;

namespace JQSelenium.Specs
{
    public class when_getting_a_tag : given_a_jquery_factory_context
    {
        static JQueryTag _result;
        static JQueryTag _expectedTag;

        Establish context = () =>
            {
                _expectedTag = new JQueryTag
                                   {
                                       TagName = "body",
                                       WebElement = (IWebElement) Driver.FindElementByTagName("body"),
                                       Selector = "jQuery.find('body')[0]"
                                   };
            };

        Because of = () => _result = jQueryFactory.Query("body").Get();

        It should_return_the_expected_tag = () => _result.IsExpectedToBeLike(_expectedTag);
    }
}
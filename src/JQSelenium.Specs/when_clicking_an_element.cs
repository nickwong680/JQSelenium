using System;
using Machine.Specifications;
using OpenQA.Selenium.Support.UI;

namespace JQSelenium.Specs
{
    public class when_clicking_an_element : given_a_jquery_factory_context
    {
        static JQuerySelector _selector;
        static string _expectedResult;
        static WebDriverWait _wait;

        Establish context = () =>
            {
                _wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 60));
                _selector = JQuery.Find("button");
                _expectedResult = "http://api.jquery.com/?ns0=1&s=&go=";
            };

        Because of = () =>
            {
                _selector.Click();
                _wait.Until(x => !Driver.Url.Equals("http://api.jquery.com/find/"));
            };

        It should_trigger_mouse_event = () => _wait.Until(x => Driver.Url.ShouldEqual(_expectedResult));

        Cleanup when_finished = () => { };
    }
}
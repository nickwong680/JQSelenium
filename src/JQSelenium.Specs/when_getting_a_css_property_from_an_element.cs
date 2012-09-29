using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_getting_a_css_property_from_an_element
    {
        private static JQueryFactory _jQuery;
        static string expected_color;
        private static JQueryTag testing_tag;
        private static string _result;
        Establish context = () =>
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/");
            _jQuery = new JQueryFactory(driver);
            expected_color = "rgba(221, 221, 221, 1)";
            JQuerySelector testingSelector = _jQuery.Query("h1");
            testing_tag = testingSelector.Get();
        };

        private Because of = () => _result = testing_tag.css("color");

        It should_return_the_tags_name = () => _result.ShouldEqual(expected_color);

        Cleanup loaded_context = () => driver.Close();
        static FirefoxDriver driver;
    }
}

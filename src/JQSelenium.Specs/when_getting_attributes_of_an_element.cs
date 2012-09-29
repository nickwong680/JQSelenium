using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_getting_attributes_of_an_element
    {
        private static JQueryFactory _jQuery;
        static string expected_class_name;
        private static JQueryTag testing_tag;
        private static string _result;
        Establish context = () =>
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/");
            _jQuery = new JQueryFactory(driver);
            expected_class_name = "testing_class";
            JQuerySelector testing_selector = _jQuery.Query("h1");
            testing_selector = testing_selector.addClass(expected_class_name);
            testing_tag = testing_selector.Get();
        };

        private Because of = () => _result = testing_tag.attr("class");

        It should_return_the_tags_name = () => _result.ShouldEqual(expected_class_name);

        Cleanup loaded_context = () => driver.Close();
        static FirefoxDriver driver;
    }
}

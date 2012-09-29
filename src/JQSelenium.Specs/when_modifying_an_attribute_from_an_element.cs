using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_modifying_an_attribute_from_an_element
    {
        private static JQueryFactory _jQuery;
        static string expected_class_name;
        private static string _result;
        private static JQuerySelector testing_selector;
        Establish context = () =>
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/");
            _jQuery = new JQueryFactory(driver);
            expected_class_name = "testing_class";
            testing_selector = _jQuery.Query("h1");
            testing_selector = testing_selector.addClass("InitialClassName");
        };

        private Because of = () => {
            testing_selector = testing_selector.attr("class", expected_class_name);
            _result = testing_selector.Get().attr("class");
        };

        It should_have_the_attribute_modified = () => _result.ShouldEqual(expected_class_name);

        Cleanup loaded_context = () => driver.Close();

        static FirefoxDriver driver;
    }
}

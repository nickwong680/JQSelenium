using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_modifying_a_css_property_from_an_element
    {
        private static JQueryFactory _jQuery;
        static string new_color;
        private static string _result;
        private static JQuerySelector testing_selector;
        Establish context = () =>
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/");
            _jQuery = new JQueryFactory(driver);
            new_color = "rgba(0, 1, 1, 1)";
            testing_selector = _jQuery.Query("h1");
        };

        private Because of = () =>
        {
            testing_selector = testing_selector.css("color", new_color);
            _result = testing_selector.Get().css("color");
        };

        It should_have_the_attribute_modified = () => _result.ShouldEqual(new_color);

        Cleanup loaded_context = () => driver.Close();
        static FirefoxDriver driver;
    }
}

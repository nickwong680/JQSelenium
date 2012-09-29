using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_checking_if_an_element_has_a_class
    {
        static JQueryFactory _jquery;
        private static JQuerySelector _testing_selector;
        private static string _testing_class;
        private static bool _has_class;

        Establish context = () =>
        {
            _testing_class = "new_Class";
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/");
            _jquery = new JQueryFactory(driver);
            _testing_selector = _jquery.Query("h1").addClass(_testing_class);
        };

        private Because of = () => _has_class = _testing_selector.hasClass(_testing_class);

        private It should_return_the_modified_element = () => _has_class.ShouldBeTrue();

        Cleanup loaded_context = () => driver.Close();
        static FirefoxDriver driver;
    }
}

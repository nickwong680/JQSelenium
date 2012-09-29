using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{ //-----> Pending
    internal class when_adding_content_after_selector
    {
        private static JQuerySelector _testing_selector;
        private static string _new_tag;
        private static string _new_text;
        private static JQuerySelector _expected_selector;
        private static JQueryFactory jqf;
        private Establish context = () =>
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/");
            jqf = new JQueryFactory(driver);
            _testing_selector = jqf.Query("h1");
            _new_text = "Probando";
            _new_tag = "<p id = \"jQ-selenium\">" + _new_text + "</p>";
        };

        private Because of = () => { 
            _testing_selector.after(_new_tag);
            _expected_selector = jqf.Query("#jQ-selenium");
        };

        private It should_return_the_expected_tag = () => _expected_selector.isEmpty().ShouldBeFalse();

        Cleanup loaded_context = () => driver.Close();
        static FirefoxDriver driver;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    internal class when_appending_text_to_element
    {
        private static JQueryFactory _jquery;
        private static JQueryTag testing_element;
        private static String initial_Text;
        private static String final_Text;
        private static String appending_Text;
        private static String text_expected;
        private static JQuerySelector _expectedJquerySelectorSelector;

        private Establish context = () =>
        {                      
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/");
            _jquery = new JQueryFactory(driver);
            _expectedJquerySelectorSelector = _jquery.Query("h1");
            testing_element = _expectedJquerySelectorSelector.Get();
            initial_Text = testing_element.text();
            appending_Text = " Aw yeah";
        };

        private Because of = () => {
            testing_element.append(appending_Text);
            text_expected = (initial_Text + appending_Text).ToUpper();
        };

        private It should_have_the_expected_text= () => testing_element.text().ShouldEqual(text_expected);

        Cleanup loaded_context = () => driver.Close();
        static FirefoxDriver driver;
    }
}

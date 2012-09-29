using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_modifying_value_of_html_element
    {
        Establish context = () =>
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/");
            JQueryFactory jqf = new JQueryFactory(driver);
            JQuerySelector jqs = jqf.Query("#jq-primarySearch");
            expectedValue = "TestString";
            jqt = jqs.Get();
        };

        Because of = () => jqt.val(expectedValue);

        It should_return_value = () => jqt.val().ShouldEqual(expectedValue);

        Cleanup loaded_context = () => driver.Close();

        static JQueryTag jqt;
        static string expectedValue;
        static string resultingValue;
        static FirefoxDriver driver;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_removing_an_html_element
    {
        Establish context = () =>
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://api.jquery.com/find/");
                jqf = new JQueryFactory(driver);
                jqs = jqf.Query("h1");
            };

        Because of = () => jqs.remove();

        It should_remove_HTML_elements = () => jqf.Query("h1").ShouldBeEmpty();

        Cleanup loaded_context = () => driver.Close();

        static JQuerySelector jqs;
        static JQueryFactory jqf;
        static FirefoxDriver driver;
    }
}

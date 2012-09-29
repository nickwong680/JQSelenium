using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_removing_an_html_element_using_selector
    {
        Establish context = () =>
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://api.jquery.com/find/");
                jqf = new JQueryFactory(driver);
                jqs = jqf.Query("div");
            };

        Because of = () => jqs.remove("#jq-header");

        It should_remove_html_element = () => jqf.Query("#jq-header").ShouldBeEmpty();

        Cleanup loaded_context = () => driver.Close();

        static JQuerySelector jqs;
        static JQueryFactory jqf;
        static FirefoxDriver driver;
    }
}

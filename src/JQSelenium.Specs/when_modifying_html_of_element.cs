using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_modifying_html_of_element
    {
        Establish load_context = () =>
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://api.jquery.com/find/");
                jqf = new JQueryFactory(driver);
                jqs = jqf.Query("h1");
                jqt = jqs.Get();
                expectedHTML = "<p>TestHTML</p>";
            };

        Because of = () => jqt.html(expectedHTML);

        It should_modify_hmtl_of_element = () => jqt.html().ShouldEqual(expectedHTML);

        Cleanup loaded_context = () => driver.Close();

        static FirefoxDriver driver;
        static JQueryFactory jqf;
        static JQuerySelector jqs;
        static JQueryTag jqt;
        static string expectedHTML;
    }
}

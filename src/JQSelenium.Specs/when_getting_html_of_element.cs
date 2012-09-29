using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_getting_html_of_element
    {
        Establish load_context = () =>
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://api.jquery.com/find/");
                jqf = new JQueryFactory(driver);
                jqs = jqf.Query("h1");
                jqt = jqs.Get();
                expectedHtml = "jQuery API";
            };

        Because of = () => resultingHtml = jqt.html();

        It should_return_its_html_content = () => resultingHtml.ShouldEqual(expectedHtml);

        Cleanup loaded_context = () => driver.Close();

        static JQueryFactory jqf;
        static FirefoxDriver driver;
        static JQuerySelector jqs;
        static JQueryTag jqt;
        static string expectedHtml;
        static object resultingHtml;
    }
}

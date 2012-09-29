using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_modifying_text_of_element
    {
        static JQueryFactory _jquery;
        const string _testString = "testString";
        static JQueryTag _result;

        Establish context = () =>
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/");
            _jquery = new JQueryFactory(driver);
        };

        Because of = () => _result = _jquery.Query("body").Get().text(_testString);

        It should_return_the_modified_element = () => _result.text().ShouldEqual(_testString);

        Cleanup loaded_context = () => driver.Close();

        static FirefoxDriver driver;
    }
}

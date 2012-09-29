using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    public class given_a_jquery_factory_context
    {
        protected static FirefoxDriver Driver;
        protected static JQueryFactory jQueryFactory;

        Establish master_context = () =>
                                       {
                                           Driver = new FirefoxDriver();
                                           Driver.Navigate().GoToUrl("http://api.jquery.com/find/"); // el query
                                           jQueryFactory = new JQueryFactory(Driver);
                                       };

        Cleanup when_finished = () => Driver.Close();
    }
}
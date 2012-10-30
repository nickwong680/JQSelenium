using Machine.Specifications;
using OpenQA.Selenium.Chrome;

namespace JQSelenium.Specs
{
    public class given_a_jquery_factory_context 
    {
        protected static ChromeDriver Driver;
        protected static JQuery JQuery;

        Establish master_context = () =>
            {
                Driver = new ChromeDriver();
                Driver.Navigate().GoToUrl("http://api.jquery.com/find/"); // el query
                JQuery = new JQuery(Driver);
            };

        Cleanup when_finished = () => Driver.Quit();
    }
}
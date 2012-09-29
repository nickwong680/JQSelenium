using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Firefox;

namespace JQSelenium
{
    class Test
    {
        public static void Main(string[] args)
        {
            FirefoxDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/add/");

            JQueryFactory jqf = new JQueryFactory(driver);
            JQuerySelector jqs = jqf.Query("h1").add("h2");
            foreach (var jq in jqs)
            {
                Console.WriteLine(jq.ToString());
            }
        }
    }
}

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using JQSelenium;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FirefoxDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/add/");
            IWebElement webElement = driver.FindElement(By.TagName("h1"));
            Console.WriteLine(webElement.GetType().ToString());
            JQueryFactory jqf = new JQueryFactory(driver);
            jqf.Query("div");

        }
    }
}

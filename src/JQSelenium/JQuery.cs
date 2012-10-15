using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace JQSelenium
{
    /// <summary>
    /// It handles the creation of new JQuerySelectors.
    /// </summary>
    public class JQuery
    {
        public static IJavaScriptExecutor JavaScriptExecutor = new FirefoxDriver();

        /// <summary>
        /// Initializes a new JQuueryFactory.
        /// </summary>
        /// <param name="driver">Used to execute javaScript code.</param>
        public JQuery(IJavaScriptExecutor driver)
        {
            JavaScriptExecutor = driver;
        }

        /// <summary>
        /// Finds all the elements filtered by the provided selector
        /// </summary>
        /// <param name="selector">A string containing a selector expression to filter elements.</param>
        /// <returns>JQuerySelector containing JQueryTags each representing an element found in the DOM
        /// </returns>
        public JQuerySelector Find(string selector)
        {
            object result = JavaScriptExecutor.ExecuteScript("return jQuery.find('" + selector + "');");
            JQuerySelector jqs = null;

            if (result is ReadOnlyCollection<Object>)
            {
                jqs = new JQuerySelector("jQuery(jQuery.find('" + selector + "'))");
            }
            else
            {
                var queryResult = (ReadOnlyCollection<IWebElement>) result;
                List<IWebElement> queryResultList = queryResult.ToList();

                jqs = new JQuerySelector("jQuery(jQuery.find('" + selector + "'))", queryResultList);
            }
            return jqs;
        }

        /// <summary>
        /// Creates a jQuery object.
        /// </summary>
        /// <param name="element">A string containing the contents of the jQuery object</param>
        /// <returns>JQuerySelector containing the newly created object</returns>
        public JQuerySelector Create(string element)
        {
            return new JQuerySelector("jQuery('" + element + "')");
        }
    }
}
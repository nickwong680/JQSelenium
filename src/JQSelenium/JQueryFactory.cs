using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace JQSelenium
{
    /// <summary>
    /// It handles the creation of new JQuerySelectors.
    /// </summary>
    public class JQueryFactory
    {
        /// <summary>
        /// Used to execute javaScript code.
        /// </summary>
        readonly IJavaScriptExecutor _js;

        /// <summary>
        /// Initializes a new JQuueryFactory.
        /// </summary>
        /// <param name="driver">Used to be casted to an IJavaScriptExecuter to run javaScript code.</param>
        public JQueryFactory(IWebDriver driver)
        {
            _js = (IJavaScriptExecutor)driver;
        }

        /// <summary>
        /// Finds all the elements filtered by the provided selector
        /// </summary>
        /// <param name="selector">A string containing a selector expression to filter elements.</param>
        /// <returns>JQuerySelector containing JQueryTags each representing an element found in the DOM
        /// </returns>
        public JQuerySelector Query(string selector)
        {
            Object result = ((IJavaScriptExecutor) _js).ExecuteScript("return jQuery.find('" + selector + "');");
            JQuerySelector jqs = null;

            if (result.GetType() == typeof(ReadOnlyCollection<Object>))
            {
                jqs = new JQuerySelector(_js, "jQuery.find('" + selector + "')", new List<IWebElement>());
            }else
            {
                ReadOnlyCollection<IWebElement> queryResult = (ReadOnlyCollection<IWebElement>)result;
                List<IWebElement> queryResultList = queryResult.ToList();

                jqs = new JQuerySelector(_js, "jQuery.find('" + selector + "')", queryResultList);
            }
            return jqs;

        }

        /// <summary>
        /// Creates a jQuery object.
        /// </summary>
        /// <param name="element">A string containing the contents of the jQuery object</param>
        /// <returns>JQuerySelector containing the newly created object</returns>
        public JQuerySelector CreateJQueryElement(string element)
        {
            return new JQuerySelector(_js, "jQuery('" + element + "')",new List<IWebElement>());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace JQSelenium
{
    /// <summary>
    ///   It handles the creation of new JQuerySelectors.
    /// </summary>
    public class JQuery
    {
        public static IJavaScriptExecutor JavaScriptExecutor;

        /// <summary>
        ///   Initializes a new JQuueryFactory.
        /// </summary>
        /// <param name="driver"> Used to execute javaScript code. </param>
        public JQuery(IJavaScriptExecutor driver)
        {
            JavaScriptExecutor = driver;
        }

        /// <summary>
        ///   Creates a jQuery object.
        /// </summary>
        /// <param name="element"> A string containing the contents of the jQuery object </param>
        /// <returns> JQuerySelector containing the newly created object </returns>
        public JQuerySelector Create(string element)
        {
            return new JQuerySelector("jQuery('" + element + "')");
        }

        /// <summary>
        ///   Finds all the elements filtered by the provided selector
        /// </summary>
        /// <param name="selector"> A string containing a selector expression to filter elements. </param>
        /// <returns> JQuerySelector containing JQueryTags each representing an element found in the DOM </returns>
        public JQuerySelector Find(string selector)
        {
            object result;
            JQuerySelector jqs;
            if (JavaScriptExecutor is ChromeDriver)
            {
                result = JavaScriptExecutor.ExecuteScript("return jQuery('" + selector + "');");
            }
            else
            {
                Console.WriteLine("f");
                result = JavaScriptExecutor.ExecuteScript("return jQuery(jQuery.find('" + selector + "'));");
            }


            if (result is ReadOnlyCollection<Object>)
            {
                if (JavaScriptExecutor is ChromeDriver)
                {
                    jqs = new JQuerySelector("jQuery('" + selector + "')");
                }
                else
                {
                    Console.WriteLine("f");
                    jqs = new JQuerySelector("jQuery(jQuery.find('" + selector + "'))");
                }
            }
            else
            {
                List<IWebElement> queryResultList = ObjectToWebElementList(result);

                if (JavaScriptExecutor is ChromeDriver)
                {
                    jqs = new JQuerySelector("jQuery('" + selector + "')", queryResultList);
                }
                else
                {
                    Console.WriteLine("f");
                    jqs = new JQuerySelector("jQuery(jQuery.find('" + selector + "'))", queryResultList);
                }
            }
            return jqs;
        }
        /// <summary>
        ///   Converts an object into a list of web elements.
        /// </summary>
        /// <param name="result"> The object returned from a javascript execution. </param>
        /// <returns> A list of web elements. </returns>
        static List<IWebElement> ObjectToWebElementList(Object result)
        {
            var webElements = new List<IWebElement>();
            if (result is Dictionary<string, Object>)
            {
                var dictionary = (Dictionary<string, Object>)result;
                int length = Convert.ToInt32(dictionary["length"]);
                for (int i = 0; i < length; i++)
                {
                    webElements.Add((IWebElement)dictionary[Convert.ToString(i)]);
                }
            }
            else
            {
                webElements = new List<IWebElement>(((ReadOnlyCollection<IWebElement>)result));
            }
            return webElements;
        }
    }
}
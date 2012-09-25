
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Support.UI;

namespace JQSelenium
{
    public class JQueryTag : IJQueryTag
    {
        public string tagName { get; set; }
        public IWebElement webElement { get; set; }
        public string selector { get; set; }
        readonly IJavaScriptExecutor js;

        public JQueryTag()
        {
        }

        public JQueryTag(IJavaScriptExecutor js, string selector, int index, IWebElement webElement)
        {
            this.selector = selector + "[" + Convert.ToString(index) + "]";
            this.webElement = webElement;
            this.tagName = webElement.TagName;
            this.js = js;
        }

        ///<summary>
        /// Executes a javascript function by concatenating a prefix and a suffix to the selector of the JQueryTag.
        ///</summary>
        /// <param name="prefix">It represents all the javascript code that goes before the selector.</param>
        /// <param name="suffix">It represents all the javascript code that goes after the selector.</param>
        private Object execJS(string prefix, string suffix)
        {
            return js.ExecuteScript("return " + prefix + selector + suffix);
        }

        #region text()
        
        public string text()
        {
            return webElement.Text;
        }

        #endregion text()

        public override string ToString()
        {
            return selector;
        }

        public string GetTagName()
        {
            return webElement.TagName;
        }

        public JQueryTag append(string textString_function)
        {
            Object result;
            if (textString_function.Split('(')[0].Contains("function"))
            {
                result = execJS("jQuery(", ").append(" + textString_function + ");");
            }
            else
            {
                result = execJS("jQuery(", ").append('" + textString_function + "');");
            }
            return this;
        }
    }
}
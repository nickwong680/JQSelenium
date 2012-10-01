using System;
using OpenQA.Selenium;

namespace JQSelenium
{
    /// <summary>
    /// Represents a single jQuery Object.
    /// </summary>
    public class JQueryTag
    {
        /// <summary>
        /// Used to execute javaScript code.
        /// </summary>
        readonly IJavaScriptExecutor js;


        public JQueryTag()
        {
        }

        public JQueryTag(IJavaScriptExecutor js, string selector, int index, IWebElement webElement)
        {
            Selector = selector + "[" + Convert.ToString(index) + "]";
            WebElement = webElement;
            TagName = webElement.TagName;
            this.js = js;
        }

        /// <summary>
        /// The tag name of the HTML element.
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// The webElement of the HTML element.
        /// </summary>
        public IWebElement WebElement { get; set; }

        /// <summary>
        /// The selector used to obtain the HTML element.
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        ///  Add elements to the set of matched elements.
        /// <para>Source: http://api.jquery.com/add/ </para>
        /// </summary>
        /// <param name="selectorElementsHtml">
        /// <para>-selector A string representing a selector expression to find additional elements to add 
        /// to the set of matched elements.</para>
        /// <para>-elements One or more elements to add to the set of matched elements.</para>
        /// <para>-html An HTML fragment to add to the set of matched elements.</para>
        /// </param>
        /// <returns>JQuerySelector</returns>
        public JQuerySelector add(string selectorElementsHtml)
        {
            return ToJQuerySelector().add(selectorElementsHtml);
        }

        /// <summary>
        ///  Add elements to the set of matched elements.
        /// <para>Source: http://api.jquery.com/add/ </para>
        /// </summary>
        /// <param name="selector">
        /// A string representing a selector expression to find additional elements to add to 
        /// the set of matched elements.
        /// </param>
        /// <param name="context">
        /// The point in the document at which the selector should begin matching; similar to 
        /// the context argument of the $(selector, context) method.
        /// </param>
        /// <returns>JQuerySelector</returns>
        public JQuerySelector add(string selector, string context)
        {
            return ToJQuerySelector().add(selector, context);
        }

        /// <summary>
        /// Adds the specified class(es) to each of the set of matched elements.
        /// <para>Source: http://api.jquery.com/addClass/ </para>
        /// </summary>
        /// <param name="classNameFunction"><para>-className: One or more class names to be 
        /// added to the class attribute of each matched element.</para>
        /// <para>-function(index, currentClass): A function returning one or more space-separated 
        /// class names to be added to the existing class name(s). Receives the index position of 
        /// the element in the set and the existing class name(s) as arguments. Within the function, 
        /// this refers to the current element in the set.</para></param>
        /// <returns>JQuerySelector containing the modified elements.</returns>
        public JQuerySelector addClass(string classNameFunction)
        {
            return ToJQuerySelector().addClass(classNameFunction);
        }

        /// <summary>
        /// Insert content, specified by the parameter, after each element in the set of matched elements.
        /// <para>Source: http://api.jquery.com/after/ </para>
        /// </summary>
        /// <param name="content_content"><para>-content: HTML string, DOM element, or jQuery object to insert after 
        /// each element in the set of matched elements.</para>
        /// <para>-content: One or more additional DOM elements, arrays of elements, HTML strings, or jQuery objects to 
        /// insert after each element in the set of matched elements.</para></param>
        /// <param name="parameters">Can recieve any number of parameters</param>
        /// <returns>JQuerySelector containing the modified elements.</returns>
        public JQuerySelector after(params string[] parameters)
        {
            return ToJQuerySelector().after(parameters);
        }

        /// <summary>
        /// Insert content, specified by the parameter, to the end of each element in the set of matched elements.
        /// <para>Source: http://api.jquery.com/append/ </para>
        /// </summary>
        /// <param name="content_content">
        /// <para>-content: DOM element, HTML string, or jQuery object to insert at the end of each element in the set 
        /// of matched elements.</para>
        /// <para>-content: One or more additional DOM elements, arrays of elements, HTML strings, or jQuery objects to 
        /// insert at the end of each element in the set of matched elements.</para>
        /// </param>
        /// <param name="parameters">Can recieve any number of strings </param>
        /// <returns>JQuerySelector containing the modified elements.</returns>
        public JQuerySelector append(params string[] parameters)
        {
            return ToJQuerySelector().append(parameters);
        }

        /// <summary>
        /// Insert every element in the set of matched elements to the end of the target.
        /// <para>Source: http://api.jquery.com/appendTo/ </para>
        /// </summary>
        /// <param name="target">A selector, element, HTML string, or jQuery object; the matched set of 
        /// elements will be inserted at the end of the element(s) specified by this parameter.</param>
        /// <returns>JQuerySelector containing the modified elements.</returns>
        public JQuerySelector appendTo(string target)
        {
            return ToJQuerySelector().appendTo(target);
        }

        /// <summary>
        /// Get the value of an attribute for the first element in the set of matched elements.
        /// <para>Source: http://api.jquery.com/attr/#attr1 </para>
        /// </summary>
        /// <param name="attributeName">The name of the attribute to get.</param>
        /// <returns>String containing the element's attribute value.</returns>
        public string attr(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }

        /// <summary>
        /// Set one or more attributes for the set of matched elements.
        /// <para>Source: http://api.jquery.com/attr/#attr2 </para>
        /// </summary>
        /// <param name="attributeName">The name of the attribute to set.</param>
        /// <param name="newValue">A value to set for the attribute.</param>
        /// <returns>JQuerySelector containing the modified elements.</returns>
        public JQuerySelector attr(string attributeName, string newValue)
        {
            return ToJQuerySelector().attr(attributeName, newValue);
        }

        /// <summary>
        /// Get the value of a style property for the first element in the set of matched elements.
        /// <para>Source: http://api.jquery.com/css/#css1 </para>
        /// </summary>
        /// <param name="cssProperty">A CSS property.</param>
        /// <returns>String containing the CSS property value.</returns>
        public string css(string cssProperty)
        {
            return WebElement.GetCssValue(cssProperty);
        }

        /// <summary>
        /// Set one or more CSS properties for the set of matched elements.
        /// <para>Source: http://api.jquery.com/css/#css2 </para>
        /// </summary>
        /// <param name="cssProperty">A CSS property name.</param>
        /// <param name="new_value">A value to set for the property.</param>
        /// <returns>JQuerySelector containing the modified elements</returns>
        public JQuerySelector css(string cssProperty, string new_value)
        {
            return ToJQuerySelector().css(cssProperty, new_value);
        }

        ///<summary>
        /// Executes a javascript function by concatenating a prefix and a suffix to the selector of the JQueryTag.
        ///</summary>
        /// <param name="prefix">It represents all the javascript code that goes before the selector.</param>
        /// <param name="suffix">It represents all the javascript code that goes after the selector.</param>
        Object execJS(string prefix, string suffix)
        {
            return js.ExecuteScript("return " + prefix + Selector + suffix);
        }

        /// <summary>
        /// Returns the class of the JQueryTag.
        /// </summary>
        /// <returns>A string containing the class of the JQueryTag</returns>
        public string getClass()
        {
            return WebElement.GetAttribute("class");
        }

        /// <summary>
        /// Returns the IJavaScriptExecutor from the JQueryFactory
        /// </summary>
        /// <returns>An IJavaScriptExecutor</returns>
        public IJavaScriptExecutor getJS()
        {
            return js;
        }

        /// <summary>
        /// Provides the tag name of a webElement.
        /// </summary>
        /// <returns>A string containing the tag name of a webelement.</returns>
        public string GetTagName()
        {
            return WebElement.TagName;
        }

        /// <summary>
        /// Determine whether any of the matched elements are assigned the given class.
        /// <para>Source: http://api.jquery.com/hasClass/ </para>
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <returns>True if anly element has the provided className.
        /// <para>False if none of them has the provided className.</para></returns>
        public bool hasClass(string className)
        {
            return ToJQuerySelector().hasClass(className);
        }

        /// <summary>
        /// Get the HTML contents of the first element in the set of matched elements.
        /// <para>Source: http://api.jquery.com/html/#html1 </para>
        /// </summary>
        /// <returns>A string containing the HTML contents of the first element in the set of matched 
        /// elements.</returns>
        public string html()
        {
            return ToJQuerySelector().html();
        }

        /// <summary>
        /// Set the HTML contents of each element in the set of matched elements.
        /// <para>Source: http://api.jquery.com/html/#html2 </para>
        /// </summary>
        /// <param name="htmlString">A string of HTML to set as the content of each matched element.</param>
        /// <returns>JQuerySelector containing the modified elements.</returns>
        public JQuerySelector html(string htmlString)
        {
            return ToJQuerySelector().html(htmlString);
        }

        /// <summary>
        /// Remove the set of matched elements from the DOM.
        /// <para>Source: http://api.jquery.com/remove/ </para>
        /// </summary>
        public void remove()
        {
            ToJQuerySelector().remove();
        }

        /// <summary>
        /// Remove the set of matched elements from the DOM.
        /// <para>Source: http://api.jquery.com/remove/ </para>
        /// </summary>
        /// <param name="selector">A selector expression that filters the set of matched elements to be 
        /// removed.</param>
        public void remove(string selector)
        {
            ToJQuerySelector().remove(selector);
        }

        /// <summary>
        /// Determines if a parameter of a javaScript function requires apostrophes around it.
        /// </summary>
        /// <param name="content"> </param>
        /// <returns>True if it requires to be wrapped in apostrophes.
        /// <para>False if it doesn't require to be wrapped in apostrophes.</para></returns>
        public bool requiresApostrophe(string content)
        {
            if (content.Split('(')[0].Contains("function") || content.Split('.')[0].Contains("document")
                || content.Split('(')[0].Contains("$") || content.Split('(')[0].Contains("jQuery"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get the combined text contents of each element in the set of matched elements, including their descendants.
        /// <para>Source: http://api.jquery.com/text/#text1 </para>
        /// </summary>
        /// <returns>A string containing the text of an HTML element.</returns>
        public string text()
        {
            return WebElement.Text;
        }

        /// <summary>
        ///  Set the content of each element in the set of matched elements to the specified text.
        /// <para>Source: http://api.jquery.com/text/#text2 </para>
        /// </summary>
        /// <param name="textString">
        /// <para>textString A string of text to set as the content of each matched element.</para>
        /// <para>function(index, text) A function returning the text content to set. 
        /// Receives the index position of the element in the set and the old text value as arguments.</para>
        /// </param>
        /// <returns>JQuerySelector containing the modified elements.</returns>
        public JQuerySelector text(string textString)
        {
            return ToJQuerySelector().text(textString);
        }

        /// <summary>
        /// Includes the JQueryTag within a JQuerySelector.
        /// </summary>
        /// <returns>JQuerySelector with a single JQueryTag.</returns>
        JQuerySelector ToJQuerySelector()
        {
            return new JQuerySelector(this);
        }

        /// <summary>
        /// Returns a string that represents the current JQueryTag.
        /// </summary>
        /// <returns>A string that represents the current JQueryTag.</returns>
        public override string ToString()
        {
            return Selector;
        }

        /// <summary>
        /// Get the current value of the first element in the set of matched elements.
        /// <para>Source: http://api.jquery.com/val/#val1 </para>
        /// </summary>
        /// <returns>A string containing the current value of the first element in the set of matched elements.
        /// </returns>
        public string val()
        {
            return ToJQuerySelector().val();
        }

        /// <summary>
        /// Set the value of each element in the set of matched elements.
        /// <para>Source: http://api.jquery.com/val/#val2 </para>
        /// </summary>
        /// <param name="value">A string of text or an array of strings corresponding to the value of each 
        /// matched element to set as selected/checked.</param>
        /// <returns>JQuerySelector containing the modified elements.</returns>
        public JQuerySelector val(string value)
        {
            return ToJQuerySelector().val(value);
        }
    }
}
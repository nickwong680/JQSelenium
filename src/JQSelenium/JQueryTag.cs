using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace JQSelenium
{
    /// <summary>
    ///   Represents a single jQuery Object.
    /// </summary>
    public class JQueryTag
    {
        public JQueryTag()
        {
        }

        public JQueryTag(string selector, int index, IWebElement webElement)
        {
            Selector = selector + "[" + Convert.ToString(index) + "]";
            WebElement = webElement;
            TagName = webElement.TagName;            
        }

        /// <summary>
        ///   The tag name of the HTML element.
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        ///   The webElement of the HTML element.
        /// </summary>
        public IWebElement WebElement { get; set; }

        /// <summary>
        ///   The selector used to obtain the HTML element.
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        ///   Provides the tag name of a webElement.
        /// </summary>
        /// <returns> A string containing the tag name of a webelement. </returns>
        public string GetTagName()
        {
            return WebElement.TagName;
        }

        /// <summary>
        ///   Includes the JQueryTag within a JQuerySelector.
        /// </summary>
        /// <returns> JQuerySelector with a single JQueryTag. </returns>
        JQuerySelector ToJQuerySelector()
        {
            return new JQuerySelector(this);
        }

        /// <summary>
        ///   Returns a string that represents the current JQueryTag.
        /// </summary>
        /// <returns> A string that represents the current JQueryTag. </returns>
        public override string ToString()
        {
            return Selector;
        }

        /// <summary>
        ///   Add elements to the set of matched elements.
        ///   <para> Source: http://api.jquery.com/add/ </para>
        /// </summary>
        /// <param name="selectorElementsHtml">
        ///   <para> -selector A string representing a selector expression to find additional elements to add to the set of matched elements. </para>
        ///   <para> -elements One or more elements to add to the set of matched elements. </para>
        ///   <para> -html An HTML fragment to add to the set of matched elements. </para>
        /// </param>
        /// <returns> JQuerySelector </returns>
        public JQuerySelector Add(string selectorElementsHtml)
        {
            return ToJQuerySelector().Add(selectorElementsHtml);
        }

        /// <summary>
        ///   Add elements to the set of matched elements.
        ///   <para> Source: http://api.jquery.com/add/ </para>
        /// </summary>
        /// <param name="selector"> A string representing a selector expression to find additional elements to add to the set of matched elements. </param>
        /// <param name="context"> The point in the document at which the selector should begin matching; similar to the context argument of the $(selector, context) method. </param>
        /// <returns> JQuerySelector </returns>
        public JQuerySelector Add(string selector, string context)
        {
            return ToJQuerySelector().Add(selector, context);
        }

        /// <summary>
        ///   Adds the specified class(es) to each of the set of matched elements.
        ///   <para> Source: http://api.jquery.com/addClass/ </para>
        /// </summary>
        /// <param name="classNameFunction">
        ///   <para> -className: One or more class names to be added to the class attribute of each matched element. </para>
        ///   <para> -function(index, currentClass): A function returning one or more space-separated class names to be added to the existing class name(s). Receives the index position of the element in the set and the existing class name(s) as arguments. Within the function, this refers to the current element in the set. </para>
        /// </param>
        /// <returns> JQuerySelector containing the modified elements. </returns>
        public JQuerySelector AddClass(string classNameFunction)
        {
            return ToJQuerySelector().AddClass(classNameFunction);
        }

        /// <summary>
        ///   Insert content, specified by the parameter, after each element in the set of matched elements.
        ///   <para> Source: http://api.jquery.com/after/ </para>
        /// </summary>
        /// <param name="content_content">
        ///   <para> -content: HTML string, DOM element, or jQuery object to insert after each element in the set of matched elements. </para>
        ///   <para> -content: One or more additional DOM elements, arrays of elements, HTML strings, or jQuery objects to insert after each element in the set of matched elements. </para>
        /// </param>
        /// <param name="parameters"> Can recieve any number of parameters </param>
        /// <returns> JQuerySelector containing the modified elements. </returns>
        public JQuerySelector After(params string[] parameters)
        {
            return ToJQuerySelector().After(parameters);
        }

        /// <summary>
        ///   Insert content, specified by the parameter, to the end of each element in the set of matched elements.
        ///   <para> Source: http://api.jquery.com/append/ </para>
        /// </summary>
        /// <param name="content_content">
        ///   <para> -content: DOM element, HTML string, or jQuery object to insert at the end of each element in the set of matched elements. </para>
        ///   <para> -content: One or more additional DOM elements, arrays of elements, HTML strings, or jQuery objects to insert at the end of each element in the set of matched elements. </para>
        /// </param>
        /// <param name="parameters"> Can recieve any number of strings </param>
        /// <returns> JQuerySelector containing the modified elements. </returns>
        public JQuerySelector Append(params string[] parameters)
        {
            return ToJQuerySelector().Append(parameters);
        }

        /// <summary>
        ///   Insert every element in the set of matched elements to the end of the target.
        ///   <para> Source: http://api.jquery.com/appendTo/ </para>
        /// </summary>
        /// <param name="target"> A selector, element, HTML string, or jQuery object; the matched set of elements will be inserted at the end of the element(s) specified by this parameter. </param>
        /// <returns> JQuerySelector containing the modified elements. </returns>
        public JQuerySelector AppendTo(string target)
        {
            return ToJQuerySelector().AppendTo(target);
        }

        /// <summary>
        ///   Get the value of an attribute for the first element in the set of matched elements.
        ///   <para> Source: http://api.jquery.com/attr/#attr1 </para>
        /// </summary>
        /// <param name="attributeName"> The name of the attribute to get. </param>
        /// <returns> String containing the element's attribute value. </returns>
        public string Attr(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }

        /// <summary>
        ///   Set one or more attributes for the set of matched elements.
        ///   <para> Source: http://api.jquery.com/attr/#attr2 </para>
        /// </summary>
        /// <param name="attributeName"> The name of the attribute to set. </param>
        /// <param name="newValue"> A value to set for the attribute. </param>
        /// <returns> JQuerySelector containing the modified elements. </returns>
        public JQuerySelector Attr(string attributeName, string newValue)
        {
            return ToJQuerySelector().Attr(attributeName, newValue);
        }

        public JQuerySelector Children()
        {
            return ToJQuerySelector().Children();
        }

        /// <summary>
        ///   Get the children of each element in the set of matched elements filtered by a selector
        /// </summary>
        /// <returns> jQuerySelector containing the children of the specified set of elements</returns>
        public JQuerySelector Children(string selector)
        {
            return ToJQuerySelector().Children(selector);
        }

        /// <summary>
        ///   Bind an event handler to the "click" JavaScript event, or trigger that event on an element.
        /// </summary>
        public void Click()
        {
            ToJQuerySelector().Click();
        }

        /// <summary>
        ///   Get the value of a style property for the first element in the set of matched elements.
        ///   <para> Source: http://api.jquery.com/css/#css1 </para>
        /// </summary>
        /// <param name="cssProperty"> A CSS property. </param>
        /// <returns> String containing the CSS property value. </returns>
        public string Css(string cssProperty)
        {
            return WebElement.GetCssValue(cssProperty);
        }

        /// <summary>
        ///   Set one or more CSS properties for the set of matched elements.
        ///   <para> Source: http://api.jquery.com/css/#css2 </para>
        /// </summary>
        /// <param name="cssProperty"> A CSS property name. </param>
        /// <param name="new_value"> A value to set for the property. </param>
        /// <returns> JQuerySelector containing the modified elements </returns>
        public JQuerySelector Css(string cssProperty, string new_value)
        {
            return ToJQuerySelector().Css(cssProperty, new_value);
        }

        ///<summary>
        ///  Executes a javascript function by concatenating a prefix and a suffix to the selector of the JQueryTag.
        ///</summary>
        ///<param name="prefix"> It represents all the javascript code that goes before the selector. </param>
        ///<param name="suffix"> It represents all the javascript code that goes after the selector. </param>
        Object ExecJs(string prefix, string suffix)
        {
            return JQuery.JavaScriptExecutor.ExecuteScript("return " + prefix + Selector + suffix);
        }

        /// <summary>
        ///   Get the descendants of each element in the current set of matched elements, filtered by a selector, jQuery 
        ///   object, or element.
        ///   <para> Source: http://api.jquery.com/find/ </para>
        /// </summary>
        /// <param name="selector"> A string containing a selector expression to match elements against. </param>
        /// <returns> A JQuerySelector containing the descedants filtered by the selector. </returns>
        public JQuerySelector Find(string selector)
        {
            return ToJQuerySelector().Find(selector);
        }

        /// <summary>
        ///   Returns the class of the JQueryTag.
        /// </summary>
        /// <returns> A string containing the class of the JQueryTag </returns>
        public string GetClass()
        {
            return WebElement.GetAttribute("class");
        }

        /// <summary>
        ///   Determine whether any of the matched elements are assigned the given class.
        ///   <para> Source: http://api.jquery.com/hasClass/ </para>
        /// </summary>
        /// <param name="className"> The class name to search for. </param>
        /// <returns> True if anly element has the provided className.
        ///   <para> False if none of them has the provided className. </para>
        /// </returns>
        public bool HasClass(string className)
        {
            return ToJQuerySelector().HasClass(className);
        }

        /// <summary>
        ///   Get the HTML contents of the first element in the set of matched elements.
        ///   <para> Source: http://api.jquery.com/html/#html1 </para>
        /// </summary>
        /// <returns> A string containing the HTML contents of the first element in the set of matched elements. </returns>
        public string Html()
        {
            return ToJQuerySelector().Html();
        }

        /// <summary>
        ///   Set the HTML contents of each element in the set of matched elements.
        ///   <para> Source: http://api.jquery.com/html/#html2 </para>
        /// </summary>
        /// <param name="htmlString"> A string of HTML to set as the content of each matched element. </param>
        /// <returns> JQuerySelector containing the modified elements. </returns>
        public JQuerySelector Html(string htmlString)
        {
            return ToJQuerySelector().Html(htmlString);
        }

        /// <summary>
        ///   Get the parent of each element in the current set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <returns> A JQuerySelector containing the parent of each element in the current set of elements. </returns>
        public JQuerySelector Parent()
        {
            return ToJQuerySelector().Parent();
        }

        /// <summary>
        ///   Remove the set of matched elements from the DOM.
        ///   <para> Source: http://api.jquery.com/remove/ </para>
        /// </summary>
        public void Remove()
        {
            ToJQuerySelector().Remove();
        }

        /// <summary>
        ///   Remove the set of matched elements from the DOM.
        ///   <para> Source: http://api.jquery.com/remove/ </para>
        /// </summary>
        /// <param name="selector"> A selector expression that filters the set of matched elements to be removed. </param>
        public void Remove(string selector)
        {
            ToJQuerySelector().Remove(selector);
        }

        /// <summary>
        ///   Determines if a parameter of a javaScript function requires apostrophes around it.
        /// </summary>
        /// <param name="content"> </param>
        /// <returns> True if it requires to be wrapped in apostrophes.
        ///   <para> False if it doesn't require to be wrapped in apostrophes. </para>
        /// </returns>
        public bool RequiresApostrophe(string content)
        {
            if (content.Split('(')[0].Contains("function") || content.Split('.')[0].Contains("document")
                || content.Split('(')[0].Contains("$") || content.Split('(')[0].Contains("jQuery"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///   Get the combined text contents of each element in the set of matched elements, including their descendants.
        ///   <para> Source: http://api.jquery.com/text/#text1 </para>
        /// </summary>
        /// <returns> A string containing the text of an HTML element. </returns>
        public string Text()
        {
            return ToJQuerySelector().Text();
        }

        public string GetSelector()
        {
            return Selector;
        }

        /// <summary>
        ///   Set the content of each element in the set of matched elements to the specified text.
        ///   <para> Source: http://api.jquery.com/text/#text2 </para>
        /// </summary>
        /// <param name="textString">
        ///   <para> textString A string of text to set as the content of each matched element. </para>
        ///   <para> function(index, text) A function returning the text content to set. Receives the index position of the element in the set and the old text value as arguments. </para>
        /// </param>
        /// <returns> JQuerySelector containing the modified elements. </returns>
        public JQuerySelector Text(string textString)
        {
            return ToJQuerySelector().Text(textString);
        }

        /// <summary>
        ///   Get the current value of the first element in the set of matched elements.
        ///   <para> Source: http://api.jquery.com/val/#val1 </para>
        /// </summary>
        /// <returns> A string containing the current value of the first element in the set of matched elements. </returns>
        public string Val()
        {
            return ToJQuerySelector().Val();
        }

        /// <summary>
        ///   Set the value of each element in the set of matched elements.
        ///   <para> Source: http://api.jquery.com/val/#val2 </para>
        /// </summary>
        /// <param name="value"> A string of text or an array of strings corresponding to the value of each matched element to set as selected/checked. </param>
        /// <returns> JQuerySelector containing the modified elements. </returns>
        public JQuerySelector Val(string value)
        {
            return ToJQuerySelector().Val(value);
        }

        /// <summary>
        /// Get the immediately following sibling of each element in the set of matched elements. 
        /// </summary>
        /// <returns>A JQuerySelector containing the following sibling of each element in the set of elements.</returns>
        public JQuerySelector Next()
        {
            return ToJQuerySelector().Next();
        }

        /// <summary>
        /// Get the immediately following sibling of each element in the set of matched elements filtered by a selector
        /// </summary>
        /// <returns>A JQuerySelector containing the following sibling of each element in the set of elements.</returns>
        public JQuerySelector Next(string selector)
        {
            return ToJQuerySelector().Next(selector);
        }

        /// <summary>
        /// Get all preceding siblings of each element in the set of matched elements.
        /// </summary>
        /// <returns> A JQuerySelector with all the previous elements </returns>
        public JQuerySelector Prev()
        {
            return ToJQuerySelector().Prev();
        }

        /// <summary>
        /// Get all preceding siblings of each element in the set of matched elements filtered by a selector
        /// </summary>
        /// <returns> A JQuerySelector with all the previous elements </returns>
        public JQuerySelector Prev(string selector)
        {
            return ToJQuerySelector().Prev(selector);
        }

        /// <summary>
        /// Get all the previous elements of a specific jQuerySelector 
        /// </summary>
        /// <returns> A JQuerySelector with all the previous elements </returns>
        public JQuerySelector PrevAll()
        {
            return ToJQuerySelector().PrevAll();
        }

        /// <summary>
        /// Given a jQuery object that represents a set of DOM elements, the .nextAll() method allows us to search through the successors 
        /// of these elements in the DOM tree and construct a new jQuery object from the matching elements.
        /// </summary>
        /// <returns>A JQuerySelector containing the matching elements.</returns>
        public JQuerySelector NextAll()
        {
            return ToJQuerySelector().NextAll();
        }

        /// <summary>
        ///   Add the previous set of elements on the stack to the current set.
        /// </summary>
        /// <returns> jQuerySelector containing the previous set elements and the current one </returns>
        public JQuerySelector AndSelf()
        {
            return ToJQuerySelector().AndSelf();
        }

        /// <summary>
        ///   Compares if two JQueryTags have the same tag and webElement
        /// </summary>
        /// <returns> true if the JQueryTags match </returns>
        public bool Equals(JQueryTag comparer)
        {
            if ((this.TagName.Equals(comparer.TagName)) && (this.WebElement.Equals(comparer.WebElement)))
                return true;
            return false;
        }
        
    }
}
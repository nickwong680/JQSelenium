using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
//using System.Windows.Forms;

namespace JQSelenium
{
    public class JQuerySelector : IJQuerySelector
    {
        private List<JQueryTag> subset;
        private string selector;
        private int iterator;
        private readonly IJavaScriptExecutor js;

        #region Constructors
        public JQuerySelector()
        {
            this.subset = new List<JQueryTag>();
        }

        public JQuerySelector(IJavaScriptExecutor js, string selector, List<IWebElement> subset)
        {
            this.selector = selector;
            this.iterator = 0;
            this.subset = new List<JQueryTag>();
            this.js = js;
            
            for (int i = 0; i < subset.Count; i++)
            {
                this.subset.Add(new JQueryTag(js,selector,i,subset[i]));
            }
        }
        #endregion 


        

        private Object execJS(string preselector, string selector)
        {
            Console.WriteLine(preselector + this.selector + selector);
            js.ExecuteScript(preselector + selector);
            return js.ExecuteScript("return " + this.selector);
        }

        private Object retJS(string preselector, string selector)
        {
            return js.ExecuteScript("return " + preselector + this.selector + selector);
        }

        public JQueryTag Get()
        {
            return subset[iterator++];
        }

        private List<JQueryTag> objectToList(Object result)
        {
            if (result.GetType() == (new Dictionary<string, Object>()).GetType())
            {
                Dictionary<string, Object> dictionary = (Dictionary<string, Object>) result;
                int length = (int)dictionary["length"];
                List<JQueryTag> list = new List<JQueryTag>();
                for (int i = 0; i < length; i++)
                {
                    list.Add(new JQueryTag(js, selector, i, (IWebElement)dictionary[Convert.ToString(i)]));
                }
                return list;
            }else
            {
                List<IWebElement> webElements = new List<IWebElement>(((ReadOnlyCollection<IWebElement>)result));
                List<JQueryTag> jQueryTags = new List<JQueryTag>();
                for (int i = 0; i < subset.Count; i++)
                {
                    jQueryTags.Add(new JQueryTag(js, selector, i, webElements[i]));
                }
                return jQueryTags;
            }


        }

        /// <summary>
        ///  Set the content of each element in the set of matched elements to the specified text.
        /// </summary>
        /// <param name="function">function(index, text) A function returning the text content to set. 
        /// Receives the index position of the element in the set and the old text value as arguments.</param>
        /// <returns>jQuery</returns>
        public JQuerySelector text(string textString_function)
        {
            Object result;
            if(textString_function.Split('(')[0].Contains("function"))
            {
                result = execJS("jQuery(", ").text(" + textString_function + ");");
            }else
            {
                result = execJS("jQuery(", ").text('" + textString_function + "');");
            }
            this.subset = objectToList(result);
            return this;
        }

        public JQuerySelector append(string textString_function)
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
            this.subset = objectToList(result);
            return this;
        }

        public JQuerySelector addClass(string new_Class)
        {
            //Vos decis meter jQuery( aqui?
            Console.WriteLine(selector + ".addClass('" + new_Class + "');");
            execJS("jQuery( "+ selector + ")", ".addClass('" + new_Class + "');");
            return this;
        }

        public JQuerySelector add(string selector_element_html)
        {
            Console.WriteLine("jQuery(" + selector +  ").add('" + selector_element_html + "');");
            Object result;
            if(selector_element_html.Split('.')[0].Contains("document"))
            {
                result = execJS("jQuery(", ").add(" + selector_element_html + ");");
            }else
            {
                result = retJS("jQuery(", ").add('" + selector_element_html + "');");
            }
            this.subset = objectToList(result);
            return this;
        }

        public JQuerySelector add(string selector, string context)
        {
            Dictionary<string, Object> result = (Dictionary<string, Object>)execJS("jQuery(", ").add('" + selector + "'," + context + ");");
            this.subset = objectToList(result);
            return this;
        }

        #region IEnumerator
        public IEnumerator<JQueryTag> GetEnumerator()
        {
            for (int i = 0; i < subset.Count; i++)
            {
                yield return subset[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion 
    }
}
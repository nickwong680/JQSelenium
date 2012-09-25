using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace JQSelenium
{
    public class JQueryFactory
    {
        readonly IJavaScriptExecutor js;

        public JQueryFactory(IWebDriver driver)
        {
            js = (IJavaScriptExecutor)driver;
        }

        public JQuerySelector Query(string selector)
        {
            ReadOnlyCollection<IWebElement> queryResult = (ReadOnlyCollection<IWebElement>)((IJavaScriptExecutor)js).ExecuteScript("return jQuery.find('" + selector + "');");
            List<IWebElement> queryResultList = queryResult.ToList();
            

            JQuerySelector jqs = new JQuerySelector(js, "jQuery.find('" + selector + "')", queryResultList);
            return jqs;
        }

        private Object exec(JQueryTag jqt, string selector)
        {
            Object result = js.ExecuteScript(jqt.selector + selector);
            return result;
        }
    }
}
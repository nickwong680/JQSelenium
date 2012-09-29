##JQSelenium
==========
###General Information
This library was inspired by SeleniumJQuery (made by Nthalk for java, https://github.com/Nthalk/SeleniumJQuery). this C# library provides better usage than the jQuery Executor that comes with Selenium WebDriver.

###Function Summary
The library provides the main manipulation methods in jQuery: </br>
* add
* addClass
* after
* append
* appendTo
* attr
* css
* get
* hasClass
* remove
* text
* val

The functions try to mimic the jQuery usage, so for further reference go to [the jQuery documentation](http://api.jquery.com/category/Manipulation/)

### What do you need?
You only need to have the Selenium WebDriver (you can find it [here](http://seleniumhq.org/projects/webdriver/)), import it into your project: 

```c#
using OpenQA.Selenium.Firefox;
```
and a basic understading of jQuery.


### How to?
The library is based in three structures: 
First you have a <b>jQueryFactory</b>. It recieves the WebDriver and executes the queries: 
```c#
driver = new FirefoxDriver();
driver.Navigate().GoToUrl("URL-you-want-to-test");
jqf = new JQueryFactory(driver);
```

Then you can execute queries with the Query method: 
```c#
	jqf.Query("body");
```

The Query method returns a <b>jQuerySelector</b> wich is a list of <b>jQueryTags</b>, from any jQuerySelector or jQueryTag you can execute any of the methods listed above and that way you interact with the DOM.

### Example
```c#
FirefoxDriver driver = new FirefoxDriver(); // new webDriver
driver.Navigate().GoToUrl("http://api.jquery.com/find/"); //Navigate to the URL
JQueryFactory jqf = new JQueryFactory(driver); //Create the jQueryFactory
_testing_selector = jqf.Query("h1"); //Query the element in the DOM you want to access
_new_text = "Probando";
_new_tag = "<p id = \"jQ-selenium\">" + _new_text + "</p>"; //new Element in the DOM will be added
_testing_selector.after(_new_tag); //Adds the element after the previously queried element
```

You can see more examples in the JQSelenium.Specs folder.


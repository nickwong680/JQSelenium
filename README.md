##JQSelenium
==========
###General Information
This library was inspired by SeleniumJQuery (made by Nthalk, https://github.com/Nthalk/SeleniumJQuery). It provides better usage than the jQuery Executor that comes with Selenium WebDriver.

###Function Summary
The library provides the main manipulation methods in jQuery: 
*add
*addClass
*after
*append
*appendTo
*attr
*css
*get
*hasClass
*remove
*text
*val

The functions try to mimic the jQuery usage, so for further reference go to [the jQuery documentation](http://api.jquery.com/category/Manipulation/)

### How to?
The library is based in three structures: 
First you have a <br>jQueryFactory</br>. It recieves the WebDriver and executes the queries: 
```c#
	driver = new FirefoxDriver();
	driver.Navigate().GoToUrl("URL-you-want-to-test");
	jqf = new JQueryFactory(driver);
```

Then you can execute queries with the Query method: 
```c#
	jqf.Query("body");
```

The Query method returns a <br>jQuerySelector</br> wich is a list of <br>jQueryTags</g>, from any jQuerySelector or jQueryTag you can execute any of the methods listed above and that way you interact with the DOM.




JQuery Selectors for Selenium WebDriver


Inspired by SeleniumJQuery at https://github.com/Nthalk/SeleniumJQuery
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcklenAvenue.Testing.ExpectedObjects;
using Machine.Specifications;
using OpenQA.Selenium.Firefox;

namespace JQSelenium.Specs
{
    class when_adding_new_class_to_selector
    {
        private static JQuerySelector testing_element;
        private static string querying_tag;
        private static string new_class_to_add;
        private static string expected_Class_Name;
        private Establish context = () =>
        {
            querying_tag = "h1"; // el selector al que se le va a agregar
            new_class_to_add = "NewClassName"; //el nombre de la clase and shit
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://api.jquery.com/find/"); // el query
            JQueryFactory jqf = new JQueryFactory(driver);
            testing_element = jqf.Query(querying_tag); //digo, el query xD
            
        };

        private Because of = () =>
        {
            testing_element = testing_element.addClass(new_class_to_add); // aqui deberia agregar la clase
            expected_Class_Name = testing_element.Get()._webElement.GetAttribute("Class"); //luego obtener el nombre de la clase.. y no quebrarse xD
            String[] classes = expected_Class_Name.Split(' ');
            expected_Class_Name = classes[classes.Length - 1];
            Console.WriteLine(expected_Class_Name);
        };


        private It should_have_the_new_class_added = () => expected_Class_Name.ShouldEqual(new_class_to_add);

        Cleanup loaded_context = () => driver.Close();
        static FirefoxDriver driver;
    }
}

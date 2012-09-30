using System;
using Machine.Specifications;

namespace JQSelenium.Specs
{
    internal class when_adding_new_class_to_selector : given_a_jquery_factory_context
    {
        static JQuerySelector _testingElement;
        static string _queryingTag;
        static string _newClassToAdd;
        static string _expectedClassName;

        Establish context = () =>
            {
                _queryingTag = "h1"; // el selector al que se le va a agregar
                _newClassToAdd = "NewClassName"; //el nombre de la clase and shit
                _testingElement = jQueryFactory.Query(_queryingTag); //digo, el query xD
            };

        Because of = () =>
            {
                _testingElement = _testingElement.addClass(_newClassToAdd);
                // aqui deberia agregar la clase
                _expectedClassName = _testingElement.Get().WebElement.GetAttribute("Class");
                //luego obtener el nombre de la clase.. y no quebrarse xD
                String[] classes = _expectedClassName.Split(' ');
                _expectedClassName = classes[classes.Length - 1];
                Console.WriteLine(_expectedClassName);
            };

        It should_have_the_new_class_added = () => _expectedClassName.ShouldEqual(_newClassToAdd);
    }
}
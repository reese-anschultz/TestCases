using System;
using System.IO;
using System.Linq;
using System.Windows.Markup;
using System.Xml;
using TestCases.PublicInterfaces;

namespace TestCases
{
    public static class Program
    {
        public static void Main( /*string[] args*/)
        {
            var boolControl = new Control() { Name = "boolControl", States = new States() { new State() { Name = "true" }, new State() { Name = "false" } } };
            var originalStates = new States() { new State() { Name = "testState1" }, new State() { Name = "testState2" } };
            var originalControl = new Control() { Name = "testControl", States = originalStates };
            var originalAction = new Action() { Name = "testAction", Controls = new Controls() { boolControl, originalControl } };
            var originalActions = new Actions() { originalAction };
            var originalTestInformation = new TestInformation() { States = originalStates, Control = originalControl, Actions = originalActions };
            // Save the State to a string.
            string serializedTestInformation = XamlWriter.Save(originalTestInformation);
            Console.WriteLine($"{serializedTestInformation}");
            // Load the test information
            StringReader stringReader = new StringReader(serializedTestInformation);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            var readerLoadedTestInformation = XamlReader.Load(xmlReader) as ITestInformation ?? new TestInformation();
            Console.WriteLine(
                $"Deserialized state names={string.Join(", ", readerLoadedTestInformation.States.Select(state => state.Name))}");
            Console.WriteLine($"Deserialized control names={readerLoadedTestInformation.Control.Name}");
            Console.WriteLine(
                $"Deserialized control state names={string.Join(", ", readerLoadedTestInformation.Control.States.Select(state => state.Name))}");
            readerLoadedTestInformation.Actions.ToList().ForEach(action =>
            {
                Console.WriteLine($"Action name={action.Name}");
                action.Controls.ToList().ForEach(control =>
                {
                    Console.WriteLine($"Control name={control.Name}");
                    control.States.ToList().ForEach(state =>
                    {
                        Console.WriteLine($"State name={state.Name}");
                    });
                });
            });
        }
    }
}

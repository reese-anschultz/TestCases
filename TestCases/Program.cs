using System;
using System.IO;
using System.Linq;
using System.Windows.Markup;
using System.Xml;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;
using Action = TestCases.PublicObjects.Action;

namespace TestCases
{
    public static class Program
    {
        public static void Main( /*string[] args*/)
        {
            var boolControl = new Control() { Name = "boolControl", States = new States() { new State() { Name = "true" }, new State() { Name = "false" } } };
            var originalStates = new States() { new State() { Name = "testState1" }, new State() { Name = "testState2" } };
            var originalControl = new Control() { Name = "testControl", States = originalStates };
            var originalControls = new Controls() { originalControl };
            var originalAction = new Action() { Name = "testAction", Controls = new Controls() { boolControl, originalControl } };
            var originalActions = new Actions() { originalAction };
            var originalTestInformation = new TestInformation() { States = originalStates, Controls = originalControls, Actions = originalActions };
            // Save the State to a string.
            string serializedTestInformation = XamlWriter.Save(originalTestInformation);
            Console.WriteLine($"{serializedTestInformation}");
            // Load the test information
            StringReader stringReader = new StringReader(serializedTestInformation);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            var readerLoadedTestInformation = XamlReader.Load(xmlReader) as ITestInformation ?? new TestInformation();
            readerLoadedTestInformation.States.ToList().ForEach(state =>
            {
                Console.WriteLine($"State name={state.Name}");
            });
            readerLoadedTestInformation.Controls.ToList().ForEach(control =>
            {
                Console.WriteLine($"Control name={control.Name}");
                control.States.ToList().ForEach(state =>
                {
                    Console.WriteLine($"State name={state.Name}");
                });
            });
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
            var internals = readerLoadedTestInformation.MakeTestsInformationInternal();
            internals.Actions.ToList().ForEach(action =>
            {
                Console.WriteLine($"Internal Action name={action.Name}");
                action.Controls.ToList().ForEach(control =>
                {
                    Console.WriteLine($"Internal Control name={control.Name}");
                    control.States.ToList().ForEach(state =>
                    {
                        Console.WriteLine($"Internal State name={state.Name}");
                    });
                });
            });
        }
    }
}

using System;
using System.IO;
using System.Windows.Markup;
using System.Xml;
using TestCases.PublicInterfaces;

namespace TestCases
{
    public static class Program
    {
        public static void Main(/*string[] args*/)
        {
            var originalState = new State() { Name = "testState" };
            // Save the State to a string.
            string serializedState = XamlWriter.Save(originalState);
            Console.WriteLine($"{serializedState}");
            // Load the state
            StringReader stringReader = new StringReader(serializedState);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            var readerLoadedState = XamlReader.Load(xmlReader) as IState;
            Console.WriteLine($"Deserialized name={readerLoadedState?.Name}");
        }
    }
}

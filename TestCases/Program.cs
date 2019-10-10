using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;

namespace TestCases
{
    class Program
    {
        [STAThread] // Prevent runtime message: "The calling thread must be STA, because many UI components require this."
        static void Main(string[] args)
        {
            Button originalButton = new Button();
            originalButton.Height = 50;
            originalButton.Width = 100;
            originalButton.Background = Brushes.AliceBlue;
            originalButton.Content = "Click Me";

            // Save the Button to a string.
            string savedButton = XamlWriter.Save(originalButton);

            // Load the button
            StringReader stringReader = new StringReader(savedButton);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            Button readerLoadButton = (Button)XamlReader.Load(xmlReader);
        }
    }
}

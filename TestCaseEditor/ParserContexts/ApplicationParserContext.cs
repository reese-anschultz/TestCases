using System.IO;
using System.Windows.Markup;
using System.Xml;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;

namespace TestCaseEditor.ParserContexts
{
    public class ApplicationParserContext : ParserContext
    {
        public override string Prompt => "Application";
        public override CommandInformation[] Commands { get; }

        public ApplicationParserContext(ApplicationContext applicationContext)
        {
            Commands = new[]
            {
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "new",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        applicationContext.TestInformation = new TestInformation();
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 2,
                    CommandText = "save",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        XamlWriter.Save(applicationContext.TestInformation, File.CreateText(args[1]));
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 2,
                    CommandText = "load",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        var xmlReader = XmlReader.Create(File.OpenText(args[1]));
                        applicationContext.TestInformation = XamlReader.Load(xmlReader) as ITestInformation;
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "testinformation",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        parserContextManager.PushContext(new TestInformationParserContext(applicationContext.TestInformation));
                        return false;
                    }
                }
            };
        }
    }

}
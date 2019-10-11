using System.IO;
using System.Windows.Markup;
using System.Xml;
using TestCaseEditor.Interfaces;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;

namespace TestCaseEditor.ParserContexts
{
    public class ApplicationParserContext : ParserContext
    {
        private readonly ApplicationContext _applicationContext;

        public ApplicationParserContext(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public override string Prompt => "Application";

        protected override bool Execute(string[] args, IParserContextManager parserContextManager)
        {
            if (args.Length == 1)
            {
                var command = args[0].ToLowerInvariant();
                if (command == "new")
                {
                    _applicationContext.TestInformation = new TestInformation();
                }
                else if (command == "testinformation")
                {
                    parserContextManager.PushContext(new TestInformationParserContext(_applicationContext.TestInformation));
                }
            }
            else if (args.Length == 2)
            {
                var command = args[0].ToLowerInvariant();
                if (command == "save")
                {
                    XamlWriter.Save(_applicationContext.TestInformation, File.CreateText(args[1]));
                }
                else if (command == "load")
                {
                    XmlReader xmlReader = XmlReader.Create(File.OpenText(args[1]));
                    _applicationContext.TestInformation = XamlReader.Load(xmlReader) as ITestInformation;
                }
            }
            return false;
        }
    }
}
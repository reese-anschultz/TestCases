using System.IO;
using System.Windows.Markup;
using System.Xml;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;

namespace TestCaseEditor
{
    public class TestInformationParserContext : ParserContext
    {
        private readonly PropertyAccessor<ITestInformation> _testInformationAccessor;

        public TestInformationParserContext(PropertyAccessor<ITestInformation> testInformationAccessor)
        {
            _testInformationAccessor = testInformationAccessor;
        }

        public override string Prompt => "TestInformation";

        protected override bool Execute(string[] args, IParserContextManager parserContextManager)
        {
            if (args.Length == 1)
            {
                var command = args[0].ToLowerInvariant();
                if (command == "states")
                    parserContextManager.PushContext(new StatesParserContext(new PropertyAccessor<IStates>(() => _testInformationAccessor.Get().States, states => _testInformationAccessor.Get().States = states)));
                else if (command == "new")
                {
                    _testInformationAccessor.Set(new TestInformation());
                }
            }
            else if (args.Length == 2)
            {
                var command = args[0].ToLowerInvariant();
                if (command == "save")
                {
                    XamlWriter.Save(_testInformationAccessor.Get(), File.CreateText(args[1]));
                }
                else if (command == "load")
                {
                    XmlReader xmlReader = XmlReader.Create(File.OpenText(args[1]));
                    _testInformationAccessor.Set(XamlReader.Load(xmlReader) as ITestInformation);
                }
            }
            return false;
        }
    }
}

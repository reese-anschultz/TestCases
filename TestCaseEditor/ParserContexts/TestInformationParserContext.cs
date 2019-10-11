using TestCaseEditor.Interfaces;
using TestCases.PublicInterfaces;

namespace TestCaseEditor.ParserContexts
{
    public class TestInformationParserContext : ParserContext
    {
        private readonly ITestInformation _testInformationAccessor;

        public TestInformationParserContext(ITestInformation testInformationAccessor)
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
                    parserContextManager.PushContext(new StatesParserContext(_testInformationAccessor.States, "global"));
                else if (command == "controls")
                    parserContextManager.PushContext(new ControlsParserContext(_testInformationAccessor.Controls, "global"));
                else if (command == "actions")
                    parserContextManager.PushContext(new ActionsParserContext(_testInformationAccessor.Actions, "global"));
            }
            return false;
        }
    }
}

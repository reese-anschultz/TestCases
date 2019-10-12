using TestCases.PublicInterfaces;

namespace TestCaseEditor.ParserContexts
{
    public class TestInformationParserContext : ParserContext
    {
        public override string Prompt => "TestInformation";
        public override CommandInformation[] Commands { get; }

        public TestInformationParserContext(ITestInformation testInformationAccessor)
        {
            Commands = new[]
            {
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "states",
                    CommandImplementation = (args, parserContextManager) =>
                    {
                        parserContextManager.PushContext(new StatesParserContext(testInformationAccessor.States, "global"));
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "controls",
                    CommandImplementation = (args, parserContextManager) =>
                    {
                        parserContextManager.PushContext(new ControlsParserContext(testInformationAccessor.Controls, "global"));
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "actions",
                    CommandImplementation = (args, parserContextManager) =>
                    {
                        parserContextManager.PushContext(new ActionsParserContext(testInformationAccessor.Actions, "global"));
                        return false;
                    }
                }
            };
        }
    }
}

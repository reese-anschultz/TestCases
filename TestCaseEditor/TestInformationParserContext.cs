﻿using System.IO;
using System.Windows.Markup;
using System.Xml;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;

namespace TestCaseEditor
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
                    parserContextManager.PushContext(new StatesParserContext(_testInformationAccessor.States));
                else if (command == "controls")
                    parserContextManager.PushContext(new ControlsParserContext(_testInformationAccessor.Controls));
                else if (command == "actions")
                    parserContextManager.PushContext(new ActionsParserContext(_testInformationAccessor.Actions));
            }
            return false;
        }
    }
}

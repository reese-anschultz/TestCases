﻿namespace TestCaseEditor
{
    public interface IParserContext
    {
        string Prompt { get; }
        bool ParseAndExecute(string line, IParserContextManager dynamicParserContext);
    }
}
using System;
using TestCaseEditor.Interfaces;

namespace TestCaseEditor
{
    public class CommandInformation
    {
        public int ArgumentCount { get; set; }
        public string CommandText { get; set; }
        public Func<string[], IParserContextManager, bool> CommandImplementation { get; set; }
    }
}

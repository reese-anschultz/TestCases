namespace TestCaseEditor.Interfaces
{
    public interface IParserContext
    {
        string Prompt { get; }
        bool ParseAndExecute(string line, IParserContextManager dynamicParserContext);
        CommandInformation[] Commands { get; }
    }
}

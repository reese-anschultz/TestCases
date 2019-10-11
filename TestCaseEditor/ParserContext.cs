namespace TestCaseEditor
{
    public abstract class ParserContext : IParserContext
    {
        public abstract string Prompt { get; }

        public bool ParseAndExecute(string line, IParserContextManager parserContextManager)
        {
            return Execute(line.Split(" "), parserContextManager);
        }

        protected abstract bool Execute(string[] args, IParserContextManager parserContextManager);
    }
}

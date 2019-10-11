using System;
using System.Collections.Generic;

namespace TestCaseEditor
{
    public class CombinedParserContextManager : ParserContext, ICombinedParserContextManager
    {
        private readonly Stack<IParserContext> _stackParserContexts = new Stack<IParserContext>();

        public CombinedParserContextManager(IParserContext currentContext)
        {
            PushContext(currentContext);
        }

        public override string Prompt => _stackParserContexts.Peek().Prompt;

        protected override bool Execute(string[] args, IParserContextManager parserContextManager)
        {
            if (args.Length == 1)
            {
                var command = args[0].ToLowerInvariant();
                if (command == "pop" && _stackParserContexts.Count > 1)
                {
                    _stackParserContexts.Pop();
                    return false;

                }
                if (command == "quit")
                    return true;

            }
            return _stackParserContexts.Peek().ParseAndExecute(string.Join(" ", args), parserContextManager);
        }

        public void PushContext(IParserContext parserContext)
        {
            if (ReferenceEquals(this, parserContext))
                throw new ArgumentException($"Circular parser context reference detected", nameof(parserContext));

            _stackParserContexts.Push(parserContext);
        }
    }
}

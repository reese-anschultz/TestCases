using System;
using System.Collections.Generic;
using System.Linq;
using TestCaseEditor.Interfaces;

namespace TestCaseEditor
{
    public class CombinedParserContextManager : ParserContext, IParserContextManager
    {
        public override string Prompt => _stackParserContexts.Peek().Prompt;
        public override CommandInformation[] Commands { get; }
        private readonly Stack<IParserContext> _stackParserContexts = new Stack<IParserContext>();

        public CombinedParserContextManager(IParserContext currentContext)
        {
            PushContext(currentContext);
            Commands = new[]
            {
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "pop",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        _stackParserContexts.Pop();
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "quit",
                    CommandImplementation = (args,parserContextManager) => true
                },
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "help",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        _stackParserContexts.Peek().Commands.Select(command=>command.CommandText).Concat(this.Commands.Select(command=>command.CommandText)).ToList().ForEach(Console.WriteLine);
                        return false;

                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 0,
                    CommandText = "",
                    CommandImplementation = (args,parserContextManager) => _stackParserContexts.Peek().ParseAndExecute(string.Join(" ", args), parserContextManager)
                },
            };
        }

        public void PushContext(IParserContext parserContext)
        {
            if (ReferenceEquals(this, parserContext))
                throw new ArgumentException($"Circular parser context reference detected", nameof(parserContext));

            _stackParserContexts.Push(parserContext);
        }
    }
}

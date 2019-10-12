using System;
using System.Linq;
using TestCases.PublicInterfaces;

namespace TestCaseEditor.ParserContexts
{
    public class StatesParserContext : ParserContext
    {
        public override string Prompt => _promptPrefix + " States";
        public override CommandInformation[] Commands { get; }
        private readonly string _promptPrefix;

        public StatesParserContext(IStates states, string promptPrefix)
        {
            _promptPrefix = promptPrefix;
            Commands = new[]
            {
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "clear",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        states.Clear();
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "print",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        states.ToList().ForEach(state => Console.WriteLine(state.Name));
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 2,
                    CommandText = "add",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        if (states.Any(state => state.Name == args[1]))
                            Console.WriteLine($"Duplicate state ignored: {args[1]}");
                        else
                        {
                            var state = new TestCases.PublicObjects.State() { Name = args[1] };
                            states.Add(state);
                        }
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 2,
                    CommandText = "delete",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        var item = states.SingleOrDefault(state => state.Name == args[1]);
                        if (item == default(IState))
                            Console.WriteLine($"Missing state not deleted: {args[1]}");
                        else
                            states.Remove(item);
                        return false;
                    }
                }
            };
        }
    }
}

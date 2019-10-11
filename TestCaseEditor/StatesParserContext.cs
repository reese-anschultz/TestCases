using System;
using System.Linq;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;

namespace TestCaseEditor
{
    public class StatesParserContext : ParserContext
    {
        private readonly IStates _states;
        private readonly string _promptPrefix;

        public StatesParserContext(IStates states, string promptPrefix)
        {
            _states = states;
            _promptPrefix = promptPrefix;
        }

        public override string Prompt => _promptPrefix + " States";

        protected override bool Execute(string[] args, IParserContextManager parserContextManager)
        {
            if (args.Length > 0)
            {
                var command = args[0].ToLowerInvariant();
                switch (command)
                {
                    case "add":
                        if (args.Length == 2)
                            if (_states.Any(state => state.Name == args[1]))
                                Console.WriteLine($"Duplicate state ignored: {args[1]}");
                            else
                                _states.Add(new State() { Name = args[1] });
                        break;

                    case "delete":
                        if (args.Length == 2)
                        {
                            var item = _states.SingleOrDefault(state => state.Name == args[1]);
                            if (item == default(IState))
                                Console.WriteLine($"Missing state not deleted: {args[1]}");
                            else
                                _states.Remove(item);
                        }
                        break;

                    case "clear":
                        if (args.Length == 1)
                            _states.Clear();
                        break;

                    case "print":
                        if (args.Length == 1)
                            _states.ToList().ForEach(state => Console.WriteLine(state.Name));
                        break;

                    default:
                        Console.WriteLine($"Unknown command: {command}");
                        break;
                }
            }
            return false;
        }
    }
}

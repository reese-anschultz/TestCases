using System;
using System.Linq;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;

namespace TestCaseEditor
{
    public class StatesParserContext : ParserContext
    {
        private readonly PropertyAccessor<IStates> _states;

        public StatesParserContext(PropertyAccessor<IStates> states)
        {
            _states = states;
        }

        public override string Prompt => "States";

        protected override bool Execute(string[] args, IParserContextManager parserContextManager)
        {
            if (args.Length > 0)
            {
                var command = args[0].ToLowerInvariant();
                switch (command)
                {
                    case "add":
                        if (args.Length == 2)
                            if (_states.Get().Any(state => state.Name == args[1]))
                                Console.WriteLine($"Duplicate state ignored: {args[1]}");
                            else
                                _states.Get().Add(new State() { Name = args[1] });
                        break;

                    case "delete":
                        if (args.Length == 2)
                        {
                            var item = _states.Get().SingleOrDefault(state => state.Name == args[1]);
                            if (item == default(IState))
                                Console.WriteLine($"Missing state not deleted: {args[1]}");
                            else
                                _states.Get().Remove(item);
                        }
                        break;

                    case "print":
                        if (args.Length == 1)
                            _states.Get().ToList().ForEach(state => Console.WriteLine(state.Name));
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

using System;
using System.Linq;
using TestCases.PublicInterfaces;

namespace TestCaseEditor
{
    public class ActionsParserContext : ParserContext
    {
        private readonly IActions _actions;

        public ActionsParserContext(IActions actions)
        {
            _actions = actions;
        }

        public override string Prompt => "Actions";

        protected override bool Execute(string[] args, IParserContextManager parserContextManager)
        {
            if (args.Length > 0)
            {
                var command = args[0].ToLowerInvariant();
                switch (command)
                {
                    case "add":
                        if (args.Length == 2)
                            if (_actions.Any(action => action.Name == args[1]))
                                Console.WriteLine($"Duplicate action ignored: {args[1]}");
                            else
                                _actions.Add(new TestCases.PublicObjects.Action() { Name = args[1] });
                        break;

                    case "delete":
                        if (args.Length == 2)
                        {
                            var item = _actions.SingleOrDefault(action => action.Name == args[1]);
                            if (item == default(IAction))
                                Console.WriteLine($"Missing action not deleted: {args[1]}");
                            else
                                _actions.Remove(item);
                        }

                        break;

                    case "clear":
                        if (args.Length == 1)
                            _actions.Clear();
                        break;

                    case "print":
                        if (args.Length == 1)
                            _actions.ToList().ForEach(action => Console.WriteLine(action.Name));
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

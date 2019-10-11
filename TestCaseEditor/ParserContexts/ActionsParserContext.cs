using System;
using System.Linq;
using TestCaseEditor.Interfaces;
using TestCases.PublicInterfaces;

namespace TestCaseEditor.ParserContexts
{
    public class ActionsParserContext : ParserContext
    {
        private readonly IActions _actions;
        private readonly string _promptPrefix;

        public ActionsParserContext(IActions actions, string promptPrefix)
        {
            _actions = actions;
            _promptPrefix = promptPrefix;
        }

        public override string Prompt => _promptPrefix + " Actions";

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
                            {
                                var action = new TestCases.PublicObjects.Action() { Name = args[1] };
                                _actions.Add(action);
                                parserContextManager.PushContext(new ControlsParserContext(action.Controls, action.Name));
                            }
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

                    case "select":
                        if (args.Length == 2)
                        {
                            var item = _actions.SingleOrDefault(action => action.Name == args[1]);
                            if (item == default(IAction))
                                Console.WriteLine($"Missing action not deleted: {args[1]}");
                            else
                                parserContextManager.PushContext(new ControlsParserContext(item.Controls, item.Name));
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

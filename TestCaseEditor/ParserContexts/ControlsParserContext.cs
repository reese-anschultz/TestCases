using System;
using System.Linq;
using TestCaseEditor.Interfaces;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;

namespace TestCaseEditor.ParserContexts
{
    public class ControlsParserContext : ParserContext
    {
        private readonly IControls _controls;
        private readonly string _promptPrefix;

        public ControlsParserContext(IControls controls, string promptPrefix)
        {
            _controls = controls;
            _promptPrefix = promptPrefix;
        }

        public override string Prompt => _promptPrefix + " Controls";

        protected override bool Execute(string[] args, IParserContextManager parserContextManager)
        {
            if (args.Length > 0)
            {
                var command = args[0].ToLowerInvariant();
                switch (command)
                {
                    case "add":
                        if (args.Length == 2)
                            if (_controls.Any(control => control.Name == args[1]))
                                Console.WriteLine($"Duplicate control ignored: {args[1]}");
                            else
                            {
                                var control = new Control() { Name = args[1] };
                                _controls.Add(control);
                                parserContextManager.PushContext(new StatesParserContext(control.States, control.Name));
                            }

                        break;

                    case "delete":
                        if (args.Length == 2)
                        {
                            var item = _controls.SingleOrDefault(control => control.Name == args[1]);
                            if (item == default(IControl))
                                Console.WriteLine($"Missing control not deleted: {args[1]}");
                            else
                                _controls.Remove(item);
                        }
                        break;

                    case "select":
                        if (args.Length == 2)
                        {
                            var item = _controls.SingleOrDefault(control => control.Name == args[1]);
                            if (item == default(IControl))
                                Console.WriteLine($"Missing control not selected: {args[1]}");
                            else
                                parserContextManager.PushContext(new StatesParserContext(item.States, item.Name));
                        }
                        break;

                    case "clear":
                        if (args.Length == 1)
                            _controls.Clear();
                        break;

                    case "print":
                        if (args.Length == 1)
                            _controls.ToList().ForEach(control => Console.WriteLine(control.Name));
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

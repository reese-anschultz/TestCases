using System;
using System.Linq;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;

namespace TestCaseEditor
{
    public class ControlsParserContext : ParserContext
    {
        private readonly IControls _controls;

        public ControlsParserContext(IControls controls)
        {
            _controls = controls;
        }

        public override string Prompt => "Controls";

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
                                _controls.Add(new Control() { Name = args[1] });
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

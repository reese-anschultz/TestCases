using System;
using System.Linq;
using TestCases.PublicInterfaces;

namespace TestCaseEditor.ParserContexts
{
    public class ControlsParserContext : ParserContext
    {
        public override string Prompt => _promptPrefix + " Controls";
        public override CommandInformation[] Commands { get; }
        private readonly string _promptPrefix;

        public ControlsParserContext(IControls controls, string promptPrefix)
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
                        controls.Clear();
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "print",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        controls.ToList().ForEach(control => Console.WriteLine(control.Name));
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 2,
                    CommandText = "add",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        if (controls.Any(control => control.Name == args[1]))
                            Console.WriteLine($"Duplicate control ignored: {args[1]}");
                        else
                        {
                            var control = new TestCases.PublicObjects.Control() { Name = args[1] };
                            controls.Add(control);
                            parserContextManager.PushContext(new StatesParserContext(control.States, control.Name));
                        }
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 3,
                    CommandText = "reference",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        if (controls.Any(control => control.Name == args[1]))
                            Console.WriteLine($"Duplicate control ignored: {args[1]}");
                        else
                        {
                            var control = new TestCases.PublicObjects.ControlReference() { Name = args[1], ReferenceName = args[2] };
                            controls.Add(control);
                            parserContextManager.PushContext(new StatesParserContext(control.States, control.Name));
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
                        var item = controls.SingleOrDefault(control => control.Name == args[1]);
                        if (item == default(IControl))
                            Console.WriteLine($"Missing control not deleted: {args[1]}");
                        else
                            controls.Remove(item);
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 2,
                    CommandText = "select",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        var item = controls.SingleOrDefault(control => control.Name == args[1]);
                        if (item == default(IControl))
                            Console.WriteLine($"Missing control not selected: {args[1]}");
                        else
                            parserContextManager.PushContext(new StatesParserContext(item.States, item.Name));
                        return false;
                    }
                },
            };
        }
    }
}

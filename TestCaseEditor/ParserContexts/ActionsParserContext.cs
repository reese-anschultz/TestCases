using System;
using System.Linq;
using TestCases.PublicInterfaces;

namespace TestCaseEditor.ParserContexts
{
    public class ActionsParserContext : ParserContext
    {
        public override string Prompt => _promptPrefix + " Actions";
        public override CommandInformation[] Commands { get; }
        private readonly string _promptPrefix;

        public ActionsParserContext(IActions actions, string promptPrefix)
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
                        actions.Clear();
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 1,
                    CommandText = "print",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        actions.ToList().ForEach(action => Console.WriteLine(action.Name));
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 2,
                    CommandText = "add",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        if (actions.Any(action => action.Name == args[1]))
                            Console.WriteLine($"Duplicate action ignored: {args[1]}");
                        else
                        {
                            var action = new TestCases.PublicObjects.Action() { Name = args[1] };
                            actions.Add(action);
                            parserContextManager.PushContext(new ControlsParserContext(action.Controls, action.Name));
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
                        var item = actions.SingleOrDefault(action => action.Name == args[1]);
                        if (item == default(IAction))
                            Console.WriteLine($"Missing action not deleted: {args[1]}");
                        else
                            actions.Remove(item);
                        return false;
                    }
                },
                new CommandInformation()
                {
                    ArgumentCount = 2,
                    CommandText = "select",
                    CommandImplementation = (args,parserContextManager) =>
                    {
                        var item = actions.SingleOrDefault(action => action.Name == args[1]);
                        if (item == default(IAction))
                            Console.WriteLine($"Missing action not selected: {args[1]}");
                        else
                            parserContextManager.PushContext(new ControlsParserContext(item.Controls, item.Name));
                        return false;
                    }
                },
            };
        }
    }
}

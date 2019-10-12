using System;
using System.Linq;
using TestCaseEditor.Interfaces;

namespace TestCaseEditor
{
    public abstract class ParserContext : IParserContext
    {
        public abstract string Prompt { get; }
        public abstract CommandInformation[] Commands { get; }

        public bool ParseAndExecute(string line, IParserContextManager parserContextManager)
        {
            var args = line.Split(" ");
            var command = args[0].ToLowerInvariant();
            var commandInformation = Commands.SingleOrDefault(c => c.ArgumentCount == args.Length && c.CommandText == command) ??
                                     Commands.SingleOrDefault(c => c.ArgumentCount <= 0);   // If no matching command found, see if the parser will handle any command (ArgumentCount <= 0)
            if (commandInformation == default)
            {
                Console.WriteLine($"Unknown command: {command}");
                return false;
            }

            return commandInformation.CommandImplementation(args, parserContextManager);
        }
    }
}

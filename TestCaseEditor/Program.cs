using System;

namespace TestCaseEditor
{
    public static class Program
    {
        public static void Main(/*string[] args*/)
        {
            var applicationContext = new ApplicationContext();
            var parserContextManager = new CombinedParserContextManager(new ApplicationParserContext(applicationContext));
            var quit = false;
            while (!quit && GetLine(parserContextManager.Prompt, out var line))
            {
                quit = parserContextManager.ParseAndExecute(line, parserContextManager);
            }
        }

        private static bool GetLine(string prompt, out string line)
        {
            Console.Write(prompt + "> ");
            line = Console.ReadLine();
            return line != default;
        }
    }
}

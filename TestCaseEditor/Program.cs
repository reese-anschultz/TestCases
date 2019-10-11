using System;
using TestCases.PublicInterfaces;
using TestCases.PublicObjects;

namespace TestCaseEditor
{
    public static class Program
    {
        public static void Main(/*string[] args*/)
        {
            var testInformation = new TestInformation() as ITestInformation;
            var parserContextManager = new CombinedParserContextManager(new TestInformationParserContext(new PropertyAccessor<ITestInformation>(() => testInformation, newTestInformation => testInformation = newTestInformation)));
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

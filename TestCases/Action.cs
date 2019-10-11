using TestCases.PublicInterfaces;

namespace TestCases
{
    public class Action : IAction
    {
        public string Name { get; set; }
        public IControls Controls { get; set; }
    }
}
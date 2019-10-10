using TestCases.PublicInterfaces;

namespace TestCases
{
    public class Control : IControl
    {
        public string Name { get; set; }
        public IStates States { get; set; }
    }
}

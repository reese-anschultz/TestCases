using TestCases.PublicInterfaces;

namespace TestCases
{
    public class TestInformation : ITestInformation
    {
        public IStates States { get; set; }
        public IControl Control { get; set; }
        public IActions Actions { get; set; }
    }
}

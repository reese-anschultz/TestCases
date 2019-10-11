using TestCases.PublicInterfaces;

namespace TestCases
{
    public class TestInformation : ITestInformation
    {
        public IStates States { get; set; }
        public IControls Controls { get; set; }
        public IActions Actions { get; set; }
    }
}

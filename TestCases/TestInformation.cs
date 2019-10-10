using TestCases.PublicInterfaces;

namespace TestCases
{
    public class TestInformation : ITestInformation
    {
        public IStates States { get; set; }
    }
}

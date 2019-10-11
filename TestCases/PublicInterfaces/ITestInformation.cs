using TestCases.InternalInterfaces;

namespace TestCases.PublicInterfaces
{
    public interface ITestInformation
    {
        IStates States { get; }
        IControls Controls { get; }
        IActions Actions { get; }
        ITestInformationInternal MakeTestsInformationInternal();
    }
}

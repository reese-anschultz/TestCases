using TestCases.InternalInterfaces;

namespace TestCases.PublicInterfaces
{
    public interface ITestInformation
    {
        IStates States { get; set;  }
        IControls Controls { get; set; }
        IActions Actions { get; set;  }
        ITestInformationInternal MakeTestsInformationInternal();
    }
}

using TestCases.InternalInterfaces;

namespace TestCases.InternalObjects
{
    public class TestInformationInternal : ITestInformationInternal
    {
        public IStatesInternal States { get; set; }
        public IControlsInternal Controls { get; set; }
        public IActionsInternal Actions { get; set; }
    }
}

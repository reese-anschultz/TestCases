using TestCases.InternalInterfaces;

namespace TestCases.InternalObjects
{
    public class TestInformationInternal : ITestInformationInternal
    {
        public IStatesInternal States { get; set; } = new StatesInternal();
        public IControlsInternal Controls { get; set; } = new ControlsInternal();
        public IActionsInternal Actions { get; set; } = new ActionsInternal();
    }
}

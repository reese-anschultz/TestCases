namespace TestCases.InternalInterfaces
{
    public interface ITestInformationInternal
    {
        IStatesInternal States { get; }
        IControlsInternal Controls { get; }
        IActionsInternal Actions { get; }
    }
}

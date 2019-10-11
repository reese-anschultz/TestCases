namespace TestCases.PublicInterfaces
{
    public interface ITestInformation
    {
        IStates States { get; }
        IControl Control { get; }
        IActions Actions { get; }
    }
}

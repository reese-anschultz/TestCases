namespace TestCases.PublicInterfaces
{
    public interface IControl
    {
        string Name { get; }
        IStates States { get; }
    }
}

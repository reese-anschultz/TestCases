namespace TestCases.InternalInterfaces
{
    public interface IControlInternal
    {
        string Name { get; }
        IStatesInternal States { get; }
    }
}

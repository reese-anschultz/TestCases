using TestCases.InternalInterfaces;

namespace TestCases.PublicInterfaces
{
    public interface IState
    {
        string Name { get; }
        IStateInternal MakeStateInternal();
    }
}

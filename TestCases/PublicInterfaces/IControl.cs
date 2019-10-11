using TestCases.InternalInterfaces;

namespace TestCases.PublicInterfaces
{
    public interface IControl
    {
        string Name { get; }
        IStates States { get; }
        IControlInternal MakeControlInternal();
    }
}

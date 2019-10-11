using TestCases.InternalInterfaces;

namespace TestCases.InternalObjects
{
    public class ControlInternal : IControlInternal
    {
        public string Name { get; set; }
        public IStatesInternal States { get; set; } = new StatesInternal();
    }
}

using TestCases.InternalInterfaces;
using TestCases.InternalObjects;
using TestCases.PublicInterfaces;

namespace TestCases.PublicObjects
{
    public class ControlReference : IControl
    {
        public string Name { get; set; }
        public string ReferenceName { get; set; }
        public IStates States { get; set; } = new States();
        public IControlInternal MakeControlInternal()
        {
            return new ControlInternal() { Name = Name, States = States.MakeStatesInternal() };
        }
    }
}
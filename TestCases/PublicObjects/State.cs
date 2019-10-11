using TestCases.InternalInterfaces;
using TestCases.InternalObjects;
using TestCases.PublicInterfaces;

namespace TestCases.PublicObjects
{
    public class State : IState
    {
        public string Name { get; set; }
        public IStateInternal MakeStateInternal()
        {
            return new StateInternal() {Name = Name};
        }
    }
}

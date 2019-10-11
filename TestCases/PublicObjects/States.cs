using System.Collections.Generic;
using System.Linq;
using TestCases.InternalInterfaces;
using TestCases.InternalObjects;
using TestCases.PublicInterfaces;

namespace TestCases.PublicObjects
{
    public class States : List<IState>, IStates
    {
        public States()
        { }

        public States(IEnumerable<IState> collection) : base(collection)
        { }

        public IStatesInternal MakeStatesInternal()
        {
            return new StatesInternal(this.Select(state=> state.MakeStateInternal()));
        }
    }
}

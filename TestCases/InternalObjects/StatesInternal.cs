using System.Collections.Generic;
using TestCases.InternalInterfaces;

namespace TestCases.InternalObjects
{
    public class StatesInternal : List<IStateInternal>, IStatesInternal
    {
        public StatesInternal()
        { }

        public StatesInternal(IEnumerable<IStateInternal> collection) : base(collection)
        { }
    }
}

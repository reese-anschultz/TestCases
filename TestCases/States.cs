using System.Collections.Generic;
using TestCases.PublicInterfaces;

namespace TestCases
{
    public class States : List<State>, IStates
    {
        public States() : base()
        { }

        public States(IEnumerable<State> collection) : base(collection)
        { }

    }
}

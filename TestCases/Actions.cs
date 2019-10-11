using System.Collections.Generic;
using TestCases.PublicInterfaces;

namespace TestCases
{
    public class Actions : List<Action>, IActions
    {
        public Actions() : base()
        { }

        public Actions(IEnumerable<Action> collection) : base(collection)
        { }
    }
}
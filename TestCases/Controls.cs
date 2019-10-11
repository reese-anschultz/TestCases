using System.Collections.Generic;
using TestCases.PublicInterfaces;

namespace TestCases
{
    public class Controls : List<Control>, IControls
    {
        public Controls() : base()
        { }

        public Controls(IEnumerable<Control> collection) : base(collection)
        { }
    }
}
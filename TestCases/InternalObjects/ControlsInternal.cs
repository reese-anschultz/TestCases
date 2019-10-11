using System.Collections.Generic;
using TestCases.InternalInterfaces;

namespace TestCases.InternalObjects
{
    public class ControlsInternal : List<IControlInternal>, IControlsInternal
    {
        public ControlsInternal()
        { }

        public ControlsInternal(IEnumerable<IControlInternal> collection) : base(collection)
        { }
    }
}
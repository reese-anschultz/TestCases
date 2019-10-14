using System.Collections.Generic;
using System.Linq;
using TestCases.InternalInterfaces;
using TestCases.InternalObjects;
using TestCases.PublicInterfaces;

namespace TestCases.PublicObjects
{
    public class Controls : TestCaseList<IControl>, IControls
    {
        public Controls()
        { }

        public Controls(IEnumerable<IControl> collection) : base(collection)
        { }

        public IControlsInternal MakeControlsInternal()
        {
            return new ControlsInternal(this.Select(control => control.MakeControlInternal()));
        }
    }
}
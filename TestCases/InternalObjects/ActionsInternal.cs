using System.Collections.Generic;
using TestCases.InternalInterfaces;

namespace TestCases.InternalObjects
{
    public class ActionsInternal : List<IActionInternal>, IActionsInternal
    {
        public ActionsInternal()
        { }

        public ActionsInternal(IEnumerable<IActionInternal> collection) : base(collection)
        { }
    }
}
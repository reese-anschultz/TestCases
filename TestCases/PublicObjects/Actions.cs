using System.Collections.Generic;
using System.Linq;
using TestCases.InternalInterfaces;
using TestCases.InternalObjects;
using TestCases.PublicInterfaces;

namespace TestCases.PublicObjects
{
    public class Actions : List<IAction>, IActions
    {
        public Actions()
        { }

        public Actions(IEnumerable<IAction> collection) : base(collection)
        { }

        public IActionsInternal MakeActionsInternal()
        {
            return new ActionsInternal(this.Select(action=>action.MakeActionInternal()));
        }
    }
}
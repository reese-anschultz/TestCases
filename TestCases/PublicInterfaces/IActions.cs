using System.Collections.Generic;
using TestCases.InternalInterfaces;

namespace TestCases.PublicInterfaces
{
    public interface IActions : IList<IAction>
    {
        IActionsInternal MakeActionsInternal();
    }
}
using System.Collections.Generic;
using TestCases.InternalInterfaces;

namespace TestCases.PublicInterfaces
{
    public interface IStates : IList<IState>
    {
        IStatesInternal MakeStatesInternal();
    }
}

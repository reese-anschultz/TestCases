using System.Collections.Generic;
using TestCases.InternalInterfaces;

namespace TestCases.PublicInterfaces
{
    public interface IControls : IList<IControl>
    {
        IControlsInternal MakeControlsInternal();
    }
}
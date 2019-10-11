using TestCases.InternalInterfaces;
using TestCases.InternalObjects;
using TestCases.PublicInterfaces;

namespace TestCases.PublicObjects
{
    public class Action : IAction
    {
        public string Name { get; set; }
        public IControls Controls { get; set; }

        public IActionInternal MakeActionInternal()
        {
            return new ActionInternal() { Name = Name, Controls = Controls.MakeControlsInternal() };
        }

    }
}
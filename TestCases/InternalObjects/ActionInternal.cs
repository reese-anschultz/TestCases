using TestCases.InternalInterfaces;

namespace TestCases.InternalObjects
{
    public class ActionInternal : IActionInternal
    {
        public string Name { get; set; }
        public IControlsInternal Controls { get; set; } = new ControlsInternal();
    }
}
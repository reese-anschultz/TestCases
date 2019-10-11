namespace TestCases.InternalInterfaces
{
    public interface IActionInternal
    {
        string Name { get; }
        IControlsInternal Controls { get; }
    }
}
namespace TestCases.PublicInterfaces
{
    public interface IAction
    {
        string Name { get; }
        IControls Controls { get; }
    }
}
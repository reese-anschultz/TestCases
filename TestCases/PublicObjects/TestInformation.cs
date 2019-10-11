using TestCases.InternalInterfaces;
using TestCases.InternalObjects;
using TestCases.PublicInterfaces;

namespace TestCases.PublicObjects
{
    public class TestInformation : ITestInformation
    {
        public IStates States { get; set; } = new States();
        public IControls Controls { get; set; } = new Controls();
        public IActions Actions { get; set; } = new Actions();
        public ITestInformationInternal MakeTestsInformationInternal()
        {
            return new TestInformationInternal()
            {
                Actions = Actions.MakeActionsInternal(),
                Controls = Controls.MakeControlsInternal(),
                States = States.MakeStatesInternal()
            };
        }
    }
}

using TestCases.InternalInterfaces;
using TestCases.InternalObjects;
using TestCases.PublicInterfaces;

namespace TestCases.PublicObjects
{
    public class TestInformation : ITestInformation
    {
        public IStates States { get; set; }
        public IControls Controls { get; set; }
        public IActions Actions { get; set; }
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

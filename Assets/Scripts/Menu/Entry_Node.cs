using Unity.VisualScripting;
using UnityEngine;

namespace Menu
{
    public class Entry_Node : Unit
    {
        [DoNotSerialize] public ControlInput inputTrigger;
        [DoNotSerialize] public ControlOutput outputTrigger;
        [DoNotSerialize] public ValueInput message;

        protected override void Definition()
        {
            inputTrigger = ControlInput("In", (flow) =>
            {
                Debug.Log(flow.GetValue<string>(message));
                return outputTrigger;
            });
            outputTrigger = ControlOutput("Out");
            message = ValueInput<string>("Message", "Hallo");
        }
    }
}

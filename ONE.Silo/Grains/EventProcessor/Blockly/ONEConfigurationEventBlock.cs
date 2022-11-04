using ONE.Models.MessageContracts;
using ONE.Silo.Grains.EventProcessor.Blockly;
using Orleans;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.OdinEventProcessorService.Blocks
{


    public abstract class ONEEventFlowVariable
    {
        public abstract object GetValue();
    }
    public class ONEEventFlowVariable<T> : ONEEventFlowVariable
    {
        public T Value { get; set; }
        public override object GetValue()
        {
            return Value;
        }
    }

    public abstract class ONEConfigurationEventBlock : ONEConfigurationBlock
    {
        /// <summary>
        /// Gets or sets the event flow.
        /// </summary>
        /// <value>
        /// The event flow.
        /// </value>
        public EventFlow? EventFlow { get; set; }

        /// <summary>
        /// Gets or sets the event data.
        /// </summary>
        /// <value>
        /// This is the payload data from the event message
        /// </value>
        public dynamic? EventData { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the event flow associated with the event is halted.
        /// </summary>
        /// <value>
        /// <c>true</c> if the associated event flow is halted; otherwise, <c>false</c>.
        /// </value>
        public bool IsEventFlowHalted { get; set; }

        public bool StopAudioOnEventFlowHalt { get; set; }

        public string EventFlowLogDetailXML { get; set; }

        /// <summary>
        /// Gets or sets the eventflow variable data.
        /// </summary>
        /// <value>
        /// This is the variable data
        /// </value>        
        public ConcurrentDictionary<string, ONEEventFlowVariable> ONEEventFlowVariableDictionary { get; set; }


        public IONEEventMessage ONEEventMessage { get; set; }

        public IGrainFactory GrainFactory { get; set; }


        /// <summary>
        /// Executes the flow.
        /// </summary>
        public override async Task ExecuteFlow()
        {
            if (ONEEventFlowVariableDictionary == null)
            {
                ONEEventFlowVariableDictionary = new ConcurrentDictionary<string, ONEEventFlowVariable>();
            }
            //Execute the flow
            await base.ExecuteFlow();
        }
    }
}

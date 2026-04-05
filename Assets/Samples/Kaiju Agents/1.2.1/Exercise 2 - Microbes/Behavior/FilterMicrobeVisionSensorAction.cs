#if COM_UNITY_BEHAVIOR
using System;
using System.Linq;
using KaijuSolutions.Agents.Exercises.Microbes;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior.Exercises.Microbes
{
    /// <summary>
    /// Action to filter to specific <see cref="Microbe"/>s with a <see cref="MicrobeVisionSensor"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class FilterMicrobeVisionSensorAction : MicrobeVisionSensorAction
    {
        /// <summary>
        /// The <see cref="Microbe"/> this if for.
        /// </summary>
        protected Microbe Current { get; private set; }
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            if (base.OnStart() == Status.Failure)
            {
                return Status.Failure;
            }
            
            // Get the microbe.
            Current = sensor.Value.Agent.GetComponent<Microbe>();
            return Current ? Status.Running : Status.Failure;
        }
        
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status HandleSensor()
        {
            if (!Current)
            {
                return Status.Failure;
            }
            
            Microbe[] compatible = sensor.Value.Observed.Where(FilterCondition).ToArray();
            if (compatible.Length < 1)
            {
                return Status.Failure;
            }
            
            GetIdeal(compatible);
            return Status.Success;
        }
        
        /// <summary>
        /// How to filter for <see cref="Microbe"/>s.
        /// </summary>
        /// <param name="microbe">The <see cref="Microbe"/> being checked.</param>
        /// <returns>If this passed the filter or not.</returns>
        protected abstract bool FilterCondition(Microbe microbe);
        
        /// <summary>
        /// OnEnd is called when the node has stopped running.
        /// </summary>
        protected override void OnEnd()
        {
            base.OnEnd();
            Current = null;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Filter Microbe Vision Sensor Action - Sensor: {(sensor.Value ? sensor.Value : "None")} - Observed: {(observed.Value ? observed.Value : "None")} - {(nearest.Value ? "Nearest" : "Farthest")}";
        }
    }
}
#endif
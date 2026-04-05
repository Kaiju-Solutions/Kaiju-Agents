#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Exercises.Microbes;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace KaijuSolutions.Agents.Behavior.Exercises.Microbes
{
    /// <summary>
    /// Allow for reading a field of a <see cref="Microbe"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class ReadMicrobeAction : Action
    {
        /// <summary>
        /// The <see cref="Microbe"/> to read the value of.
        /// </summary>
        [Tooltip("The microbe to read the value of. If not assigned, it will try to find it in a variable.")]
        [SerializeReference]
        public BlackboardVariable<Microbe> microbe;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            // If no variable to read into, then this is a failure.
            if (!Assigned())
            {
                return Status.Failure;
            }
            
            microbe ??= new();
            
            // If no microbe, look for a variable.
            if (microbe.Value == null)
            {
                BlackboardReference b = GameObject.GetComponent<BehaviorGraphAgent>()?.BlackboardReference;
                if (b == null)
                {
                    return Status.Failure;
                }
                
                foreach (BlackboardVariable v in b.Blackboard.Variables)
                {
                    if (v.ObjectValue is not Microbe found && (v.ObjectValue is not GameObject o || !o.TryGetComponent(out found)) && (v.ObjectValue is not Component c || !c.TryGetComponent(out found)))
                    {
                        continue;
                    }
                    
                    microbe.Value = found;
                    break;
                }
            }
            
            // If still no microbe, this failed.
            if (!microbe.Value)
            {
                return Status.Failure;
            }
            
            // Otherwise, read it and report a success.
            ReadValue();
            return Status.Success;
        }
        
        /// <summary>
        /// If this has been validly assigned.
        /// </summary>
        /// <returns>If this has been validly assigned.</returns>
        protected abstract bool Assigned();
        
        /// <summary>
        /// Read the needed value.
        /// </summary>
        protected abstract void ReadValue();
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Read Microbe Action - Microbe: {(microbe.Value ? microbe.Value : "None")}";
        }
    }
}
#endif
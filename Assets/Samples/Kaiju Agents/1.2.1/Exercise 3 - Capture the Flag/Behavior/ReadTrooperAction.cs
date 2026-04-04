#if COM_UNITY_BEHAVIOR
using System;
using KaijuSolutions.Agents.Exercises.CTF;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace KaijuSolutions.Agents.Behavior.Exercises.CTF
{
    /// <summary>
    /// Allow for reading a field of a <see cref="Trooper"/>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class ReadTrooperAction : Action
    {
        /// <summary>
        /// The <see cref="Trooper"/> to read the value of.
        /// </summary>
        [Tooltip("The trooper to read the value of. If not assigned, it will try to find it in a variable.")]
        [SerializeReference]
        public BlackboardVariable<Trooper> trooper;
        
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
            
            trooper ??= new();
            
            // If no trooper, look for a variable.
            if (trooper.Value == null)
            {
                BlackboardReference b = GameObject.GetComponent<BehaviorGraphAgent>()?.BlackboardReference;
                if (b == null)
                {
                    return Status.Failure;
                }
                
                foreach (BlackboardVariable v in b.Blackboard.Variables)
                {
                    if (v.ObjectValue is not Trooper found && (v.ObjectValue is not GameObject o || !o.TryGetComponent(out found)) && (v.ObjectValue is not Component c || !c.TryGetComponent(out found)))
                    {
                        continue;
                    }
                    
                    trooper.Value = found;
                    break;
                }
            }
            
            // If still no trooper, this failed.
            if (!trooper.Value)
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
    }
}
#endif
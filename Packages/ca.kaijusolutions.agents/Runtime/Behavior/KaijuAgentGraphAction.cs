#if COM_UNITY_BEHAVIOR
using System;
using System.Diagnostics.CodeAnalysis;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

namespace KaijuSolutions.Agents.Behavior
{
    /// <summary>
    /// Base class to create <see href="https://docs.unity3d.com/Packages/com.unity.behavior@latest">Unity Behavior</see> actions for use with <see href="https://agents.kaijusolutions.ca">Kaiju Agents</see>.
    /// </summary>
    [Serializable]
    [GeneratePropertyBag]
    public abstract class KaijuAgentGraphAction : Action
    {
        /// <summary>
        /// The agent this is for.
        /// </summary>
        [Tooltip("The agent this is for. If it is not assigned, it will try to find an agent variable. If none are found, it will try to find an agent attached to any other component and create a variable from it.")]
        [SerializeReference]
        public BlackboardVariable<KaijuAgent> agent;
        
        /// <summary>
        /// OnStart is called when the node starts running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnStart()
        {
            return EnsureAgent();
        }
        
        /// <summary>
        /// OnUpdate is called each frame while the node is running.
        /// </summary>
        /// <returns>The status of the node.</returns>
        protected override Status OnUpdate()
        {
            return EnsureAgent();
        }
        
        /// <summary>
        /// Ensure there is an agent.
        /// </summary>
        /// <returns>Success if we have an agent, otherwise failure.</returns>
        protected Status EnsureAgent()
        {
            // If there is an agent, we are set.
            if (agent != null && agent.Value != null)
            {
                // The agent must be active.
                return agent.Value ? Status.Success : Status.Failure;
            }
            
            BlackboardVariable<KaijuAgent> found = EnsureAgent(GameObject);
            if (found == null)
            {
                return Status.Failure;
            }
            
            if (agent == null)
            {
                agent = found;
            }
            else if (agent.Value == null)
            {
                agent.Value = found.Value;
            }
            
            // The agent must be active.
            return agent.Value ? Status.Success : Status.Failure;
        }
        
        /// <summary>
        /// Ensure there is an agent.
        /// </summary>
        /// <param name="go">The current object to check the blackboard for.</param>
        /// <returns>The found or created variable or NULL if there was no agent.</returns>
        public static BlackboardVariable<KaijuAgent> EnsureAgent([NotNull] GameObject go)
        {
            // Access the Blackboard associated with this graph instance to try and assign the agent otherwise.
            BlackboardReference b = go.GetComponent<BehaviorGraphAgent>()?.BlackboardReference;
            if (b == null)
            {
                return null;
            }
            
            // Try every agent variable first.
            BlackboardVariable<KaijuAgent> cached = null;
            foreach (BlackboardVariable v in b.Blackboard.Variables)
            {
                // Get an active agent to use.
                if (v.ObjectValue is KaijuAgent a && v is BlackboardVariable<KaijuAgent> va)
                {
                    // If the agent is assigned, we are done.
                    if (a)
                    {
                        return va;
                    }
                    
                    // Otherwise, the agent field is unassigned, so we need to cache it and potentially set it later.
                    cached ??= va;
                }
            }
            
            // Try every GameObject and component one next.
            foreach (BlackboardVariable v in b.Blackboard.Variables)
            {
                // See if there is an agent attached which can be used.
                if ((v.ObjectValue is not GameObject o || !o.TryGetComponent(out KaijuAgent a)) && (v.ObjectValue is not Component c || !c.TryGetComponent(out a)))
                {
                    continue;
                }
                
                // If we had a cached agent variable, use it.
                if (cached != null)
                {
                    cached.Value = a;
                    return cached;
                }
                
                // Otherwise, create a new variable.
                string variableName = $"{v.Name} Agent";
                b.AddVariable(variableName, a);
                if (b.GetVariable(variableName, out BlackboardVariable created) && created is BlackboardVariable<KaijuAgent> va)
                {
                    return va;
                }
            }
            
            // If no agent was found, there is nothing to do.
            return null;
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Agent Graph Action - Agent: {(agent.Value ? agent.Value : "None")}";
        }
    }
}
#endif
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Samples.Movement
{
    /// <summary>
    /// Simple tester for <see cref="Agents.Movement.KaijuMovement"/>s.
    /// </summary>
    [DefaultExecutionOrder(int.MaxValue)]
#if UNITY_EDITOR
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sample-movement.html")]
#endif
    public abstract class KaijuMovementTester : KaijuBehaviour
    {
        /// <summary>
        /// The <see cref="KaijuAgent"/>s to test the <see cref="Agents.Movement.KaijuMovement"/> of.
        /// </summary>
        public List<KaijuAgent> Agents
        {
            get => agents;
            set
            {
                agents = value;
                if (value == null)
                {
                    agents.Clear();
                }
                
                OnValidate();
            }
        }
        
        /// <summary>
        /// The <see cref="KaijuAgent"/>s to test the <see cref="Agents.Movement.KaijuMovement"/> of.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The agents to test the movement of.")]
#endif
        [SerializeField]
        private List<KaijuAgent> agents = new();
        
        /// <summary>
        /// The weight of this <see cref="Agents.Movement.KaijuMovement"/>.
        /// </summary>
        public float Weight
        {
            get => weight;
            set => weight = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The weight of this <see cref="Agents.Movement.KaijuMovement"/>.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The weight of this movement.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float weight = KaijuMovement.DefaultWeight;
        
        /// <summary>
        /// If this should clear other <see cref="Agents.Movement.KaijuMovement"/>.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("If this should clear other movements.")]
#endif
        [SerializeField]
        public bool clear = true;
        
        /// <summary>
        /// Cache old movements so they can be removed before running the new movement.
        /// </summary>
        private readonly Dictionary<KaijuAgent, KaijuMovement> _cache = new();
        
        /// <summary>
        /// Ensure there is at least one agent assigned.
        /// </summary>
        private void AssignAgent()
        {
            for (int i = 0; i < agents.Count; i++)
            {
                if (agents[i] == null)
                {
                    agents.RemoveAt(i--);
                }
            }
            
            if (agents.Count > 0)
            {
                return;
            }
            
            KaijuAgent agent = GetComponent<KaijuAgent>();
            if (agent != null)
            {
                agents.Add(agent);
                return;
            }
            
            agent = GetComponentInChildren<KaijuAgent>();
            if (agent != null)
            {
                agents.Add(agent);
                return;
            }
            
            agent = GetComponentInParent<KaijuAgent>();
            if (agent != null)
            {
                return;
            }
            
            agent = FindAnyObjectByType<KaijuAgent>();
            if (agent != null)
            {
                agents.Add(agent);
            }
        }
        
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            OnValidate();
        }
        
        /// <summary>
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        /// </summary>
        private void OnValidate()
        {
            AssignAgent();
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return;
            }
#endif
            foreach (KaijuAgent agent in agents)
            {
                if (_cache.TryGetValue(agent, out KaijuMovement movement))
                {
                    agent.Stop(movement);
                    _cache.Remove(agent);
                }
                
                if (agent)
                {
                    _cache.Add(agent, Assign(agent));
                }
            }
        }
        
        /// <summary>
        /// Assign this <see cref="Agents.Movement.KaijuMovement"/> to the one of the <see cref="Agents"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see cref="Agents.Movement.KaijuMovement"/>.</returns>
        protected abstract KaijuMovement Assign([NotNull] KaijuAgent agent);
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Movement Tester {name}";
        }
    }
}
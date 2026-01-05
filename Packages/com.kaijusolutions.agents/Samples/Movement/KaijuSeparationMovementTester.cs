using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Samples.Movement
{
    /// <summary>
    /// Simple tester for <see cref="Agents.Movement.KaijuSeparationMovement"/>s.
    /// </summary>
    [DefaultExecutionOrder(int.MaxValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Samples/Movement/Kaiju Separation Movement Tester", 13)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sample-movement.html")]
#endif
    public class KaijuSeparationMovementTester : KaijuMovementTester
    {
        /// <summary>
        /// The distance to interact with other <see cref="KaijuAgent"/>s from.
        /// </summary>
        public float Distance
        {
            get => distance;
            set => distance = Mathf.Max(value, float.Epsilon);
        }
        
        /// <summary>
        /// The distance to interact with other <see cref="KaijuAgent"/>s from.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The distance to interact with other agents from.")]
#endif
        [Min(float.Epsilon)]
        [SerializeField]
        private float distance = KaijuSeparationMovement.DefaultDistance;
        
        /// <summary>
        /// The coefficient to use for inverse square law separation. Zero will use linear separation.
        /// </summary>
        public float Coefficient
        {
            get => coefficient;
            set => coefficient = Mathf.Max(value, 0);
        }
        
        /// <summary>
        /// The coefficient to use for inverse square law separation. Zero will use linear separation.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The coefficient to use for inverse square law separation. Zero will use linear separation.")]
#endif
        [Min(0)]
        [SerializeField]
        private float coefficient = KaijuSeparationMovement.DefaultCoefficient;
        
        /// <summary>
        /// What types of <see cref="KaijuAgent"/>s to avoid.
        /// </summary>
        public IReadOnlyList<uint> Identifiers => identifiers;
        
        /// <summary>
        /// What types of <see cref="KaijuAgent"/>s to avoid.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("What types of agents to avoid.")]
#endif
        [SerializeField]
        private List<uint> identifiers = new();
        
        /// <summary>
        /// Assign this <see cref="Agents.Movement.KaijuMovement"/> to the one of the <see cref="Agents"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see cref="Agents.Movement.KaijuMovement"/>.</returns>
        protected override KaijuMovement Assign([NotNull] KaijuAgent agent)
        {
            return agent.Separation(distance, coefficient, identifiers, Weight, clear);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Separation Movement Tester {name}";
        }
    }
}
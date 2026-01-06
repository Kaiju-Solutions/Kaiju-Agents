using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;
using UnityEngine;

namespace KaijuSolutions.Agents.Samples.Movement
{
    /// <summary>
    /// Simple tester for <see cref="Agents.Movement.KaijuPursueMovement"/>s.
    /// </summary>
    [DefaultExecutionOrder(int.MaxValue)]
#if UNITY_EDITOR
    [AddComponentMenu("Kaiju Solutions/Agents/Samples/Movement/Kaiju Pursue Movement Tester", 9)]
    [Icon("Packages/com.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/sample-movement.html")]
#endif
    public class KaijuPursueMovementTester : KaijuApproachingMovementTester
    {
        /// <summary>
        /// Assign this <see cref="Agents.Movement.KaijuMovement"/> to the one of the <see cref="Agents"/>.
        /// </summary>
        /// <param name="agent">The <see cref="KaijuAgent"/>.</param>
        /// <returns>The <see cref="Agents.Movement.KaijuMovement"/>.</returns>
        protected override KaijuMovement Assign([NotNull] KaijuAgent agent)
        {
            return agent.Pursue(transform, Distance, Weight, clear);
        }
        
        /// <summary>
        /// Get a description of the object.
        /// </summary>
        /// <returns>A description of the object.</returns>
        public override string ToString()
        {
            return $"Kaiju Pursue Movement Tester {name}";
        }
    }
}
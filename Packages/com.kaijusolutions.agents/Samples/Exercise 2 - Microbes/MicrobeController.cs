using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// Basic controller for you to get started with. In its current state, <see cref="Microbe"/>s simply roam around randomly.
    /// </summary>
    [DisallowMultipleComponent]
    public class MicrobeController : KaijuController
    {
        /// <summary>
        /// Callback for when the <see cref="KaijuController.Agent"/> has finishing becoming enabled.
        /// </summary>
        protected override void OnEnabled()
        {
            Agent.Wander();
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using KaijuSolutions.Agents.Movement;

namespace KaijuSolutions.Agents
{
    /// <summary>
    /// An action for an agent.
    /// </summary>
    public delegate void KaijuAction();
    
    /// <summary>
    /// An action for an agent's movement.
    /// </summary>
    /// <param name="movement">The movement this was for.</param>
    public delegate void KaijuMovementAction([NotNull] KaijuMovement movement);
}
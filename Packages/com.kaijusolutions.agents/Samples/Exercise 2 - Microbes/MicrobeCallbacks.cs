using System.Diagnostics.CodeAnalysis;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// An action for a <see cref="Microbe"/>.
    /// </summary>
    /// <param name="microbe">The <see cref="Microbe"/>.</param>
    public delegate void MircobeAction([NotNull] KaijuBehaviour microbe);
}
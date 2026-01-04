using System.Diagnostics.CodeAnalysis;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    /// <summary>
    /// An action for a <see cref="Microbe"/>.
    /// </summary>
    /// <param name="microbe">The <see cref="Microbe"/>.</param>
    public delegate void MicrobeAction([NotNull] Microbe microbe);
    
    /// <summary>
    /// An action for a two <see cref="Microbe"/>s.
    /// </summary>
    /// <param name="a">The first <see cref="Microbe"/>.</param>
    /// <param name="b">The second <see cref="Microbe"/>.</param>
    public delegate void MultiMicrobeAction([NotNull] Microbe a, [NotNull] Microbe b);
}
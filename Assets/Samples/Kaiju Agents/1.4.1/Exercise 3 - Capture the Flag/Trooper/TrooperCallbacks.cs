using System.Diagnostics.CodeAnalysis;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    /// <summary>
    /// An action for a <see cref="Trooper"/>.
    /// </summary>
    /// <param name="trooper">The <see cref="Trooper"/>.</param>
    public delegate void TrooperAction([NotNull] Trooper trooper);
    
    /// <summary>
    /// An action for two <see cref="Trooper"/>s.
    /// </summary>
    /// <param name="a">The first <see cref="Trooper"/>.</param>
    /// <param name="b">The second <see cref="Trooper"/>.</param>
    public delegate void MultiTrooperAction([NotNull] Trooper a, [NotNull] Trooper b);
    
    /// <summary>
    /// An action for a <see cref="HealthPickup"/>s.
    /// </summary>
    /// <param name="health">The <see cref="HealthPickup"/>.</param>
    public delegate void HealthAction([NotNull] HealthPickup health);
    
    /// <summary>
    /// An action for a <see cref="Trooper"/> and a <see cref="HealthPickup"/>s.
    /// </summary>
    /// <param name="trooper">The <see cref="Trooper"/>.</param>
    /// <param name="health">The <see cref="HealthPickup"/>.</param>
    public delegate void TrooperHealthAction([NotNull] Trooper trooper, [NotNull] HealthPickup health);
    
    /// <summary>
    /// An action for a <see cref="AmmoPickup"/>s.
    /// </summary>
    /// <param name="ammo">The <see cref="AmmoPickup"/>.</param>
    public delegate void AmmoAction([NotNull] AmmoPickup ammo);
    
    /// <summary>
    /// An action for a <see cref="Trooper"/> and a <see cref="AmmoPickup"/>s.
    /// </summary>
    /// <param name="trooper">The <see cref="Trooper"/>.</param>
    /// <param name="ammo">The <see cref="AmmoPickup"/>.</param>
    public delegate void TrooperAmmoAction([NotNull] Trooper trooper, [NotNull] AmmoPickup ammo);
    
    /// <summary>
    /// An action for a <see cref="Flag"/>s.
    /// </summary>
    /// <param name="flag">The <see cref="Flag"/>.</param>
    public delegate void FlagAction([NotNull] Flag flag);
    
    /// <summary>
    /// An action for a <see cref="Trooper"/> and a <see cref="Flag"/>s.
    /// </summary>
    /// <param name="trooper">The <see cref="Trooper"/>.</param>
    /// <param name="flag">The <see cref="Flag"/>.</param>
    public delegate void TrooperFlagAction([NotNull] Trooper trooper, [NotNull] Flag flag);
}
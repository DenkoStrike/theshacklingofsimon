#region

using System;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Projectiles;
using TheShacklingOfSimon.Entities.Projectiles.Augmentation;

#endregion

namespace TheShacklingOfSimon.Weapons;

public interface IWeapon
{
    string Name { get; }
    string Description { get; }
    float BaseCooldown { get; }
    int BaseDamage { get; }
    string SFX { get; }

    /// <summary>
    /// Retrieves the potentially decorated prototype projectile associated with this weapon.
    /// </summary>
    /// <returns>An instance of <see cref="IProjectile"/> representing the prototype projectile.</returns>
    IProjectile GetCurrentPrototype();

    /// <summary>
    /// Sets the prototype projectile to be used by this weapon.
    /// </summary>
    /// <remarks>
    /// If the specified newPrototype is decorated, these decorators will persist no matter what.
    /// </remarks>
    /// <param name="newPrototype">An instance of <see cref="IProjectile"/> representing the new prototype projectile.</param>
    void SetBaseProjectile(IProjectile newPrototype);

    /// <summary>
    /// Fires a projectile from the weapon starting at the specified position,
    /// moving in the given direction, using the provided projectile statistics,
    /// and using the .
    /// </summary>
    /// <param name="pos">The initial position from which the projectile is fired.</param>
    /// <param name="direction">The direction in which the projectile will travel.</param>
    /// <param name="stats">The statistics defining the properties of the fired projectile, such as damage, speed, and owner type.</param>
    void Fire(Vector2 pos, Vector2 direction, ProjectileStats stats);

    /// <summary>
    /// Adds a projectile augment to the weapon, modifying the behavior of the
    /// projectiles spawned by <c>this.Fire(...)</c>.
    /// </summary>
    /// <param name="augment">The projectile augment to add to the weapon.</param>
    /// <returns><c>true</c> if the augment was successfully added; otherwise, <c>false</c>.</returns>
    bool AddAugment(IProjectileAugment augment);

    /// <summary>
    /// Removes the specified augment from the weapon's prototype projectile decoration chain.
    /// </summary>
    /// <param name="augment">The augment to be removed, represented as an instance of <see cref="IProjectileAugment"/>.</param>
    /// <returns><c>true</c> if the augment was successfully removed; otherwise, <c>false</c>.</returns>
    bool RemoveAugment(IProjectileAugment augment);

    /// <summary>
    /// Event triggered whenever a projectile is fired from a weapon.
    /// </summary>
    /// <remarks>
    /// Observers can register for this event to process fired projectiles,
    /// such as for tracking, applying additional effects, or logging purposes.
    /// The event passes the fired projectile instance as its parameter.
    /// </remarks>
    /// <event>
    /// Raised after a projectile is successfully created and fired, using the modifiers
    /// and statistics of the weapon, as well as any attached projectile augmentations.
    /// </event>
    event Action<IProjectile> OnProjectileFired;
}
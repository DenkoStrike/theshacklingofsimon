#region

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Projectiles;
using TheShacklingOfSimon.Entities.Projectiles.Augmentation;

#endregion

namespace TheShacklingOfSimon.Weapons;

public abstract class BaseWeapon : IWeapon
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public float BaseCooldown { get; protected set; }
    public int BaseDamage { get; protected set; }
    public string SFX { get; protected set; }

    private IProjectile _baseProjectile;
    private IProjectile _prototype;
    private readonly List<IProjectileAugment> _augments;

    protected BaseWeapon(
        string name, 
        string description, 
        float baseCooldown, 
        int baseDamage, 
        IProjectile baseProjectile
        )
    {
        Name = name;
        Description = description;
        BaseCooldown = baseCooldown;
        BaseDamage = baseDamage;
        _baseProjectile = baseProjectile;
        _prototype = baseProjectile;
        _augments = new List<IProjectileAugment>();
    }
    
    public virtual void Fire(Vector2 pos, Vector2 direction, ProjectileStats stats)
    {
        var firedProjectile = _prototype.Clone(pos, direction, _prototype.Sprite, stats);
        OnProjectileFired?.Invoke(firedProjectile);
    }

    public IProjectile GetCurrentPrototype()
    {
        return _prototype;
    }
    
    public void SetBaseProjectile(IProjectile newBaseProjectile)
    {
        if (newBaseProjectile == null)
        {
            Console.WriteLine("null for parameter newBaseProjectile passed into BaseWeapon.SetPrototype.");
            return;
        }

        _baseProjectile = newBaseProjectile;
    }

    public bool AddAugment(IProjectileAugment augment)
    {
        if (augment == null) return false;
        _augments.Add(augment);
        RebuildProjectile();
        return true;
    }

    public bool RemoveAugment(IProjectileAugment augment)
    {
        if (augment != null && _augments.Remove(augment))
        {
            RebuildProjectile();
            return true;
        }

        return false;
    }
    
    private void RebuildProjectile()
    {
        IProjectile current = _baseProjectile;
        foreach (var augment in _augments)
        {
            // delegate application logic to specific augmentations
            current = augment.ApplyTo(current);
        }

        _prototype = current;
    }
    
    public event Action<IProjectile> OnProjectileFired;
}
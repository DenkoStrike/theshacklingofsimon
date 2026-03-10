using System;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Projectiles;

namespace TheShacklingOfSimon.Weapons;

public class BasicWeapon : IWeapon
{
	public string Name { get; private set; }
	public string Description { get; private set; }

	public BasicWeapon(ProjectileManager manager)
	{
		Name = "Basic Weapon";
		Description = "Fires a simple projectile.";
	}

	public void Fire(Vector2 pos, Vector2 direction, ProjectileStats stats)
	{
		var projectile = new BasicProjectile(pos, direction, stats);
		OnProjectileFired?.Invoke(projectile);
	}

	public event Action<IProjectile> OnProjectileFired;
}
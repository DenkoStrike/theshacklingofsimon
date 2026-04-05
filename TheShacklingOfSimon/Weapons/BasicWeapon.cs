#region

using TheShacklingOfSimon.Entities.Projectiles;

#endregion

namespace TheShacklingOfSimon.Weapons;

public class BasicWeapon : BaseWeapon, IPrimaryWeapon
{
	public BasicWeapon(IProjectile prototype)
	{
		Name = "Basic Weapon";
		Description = "Fires a simple projectile.";
		BaseCooldown = 0.5f;
		BaseDamage = 1;
		Prototype = prototype;
	}
}
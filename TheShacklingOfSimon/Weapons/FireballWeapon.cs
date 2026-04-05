#region

using TheShacklingOfSimon.Entities.Projectiles;

#endregion

namespace TheShacklingOfSimon.Weapons;

// Temporarily a primary weapon for sprint 4?
public class FireballWeapon : BaseWeapon, IPrimaryWeapon
{
	public FireballWeapon(IProjectile prototype)
	{
		Name = "Fireball Weapon";
		Description = "Fires a fireball projectile.";
		BaseCooldown = 0.67f;
		BaseDamage = 2;
		Prototype = prototype;
	}
}
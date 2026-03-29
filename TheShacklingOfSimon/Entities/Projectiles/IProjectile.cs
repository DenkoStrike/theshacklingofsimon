#region

using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Sprites.Products;

#endregion

namespace TheShacklingOfSimon.Entities.Projectiles;

public interface IProjectile : IEntity
{
	ProjectileStats Stats { get; }
	
	IProjectile Clone(Vector2 startPos, Vector2 direction, ISprite sprite, ProjectileStats stats);
}
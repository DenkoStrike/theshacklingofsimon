using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Entities;

namespace TheShacklingOfSimon.Projectiles;

public interface IProjectile : IEntity
{
	ProjectileStats Stats { get; }
	void Update(GameTime gameTime);
	void Draw(SpriteBatch spriteBatch);
}
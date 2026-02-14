using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.Room_Manager;

public abstract class Tile : ITile
{
	public Vector2 Position { get; protected set; }
	public Vector2 Velocity { get; set; } = Vector2.Zero;
	public bool IsActive { get; protected set; } = true;
	public virtual bool IsSolid { get; set; }
	public virtual bool BlocksProjectiles { get; set; }

	public Rectangle Hitbox =>
		new Rectangle(
			(int)Position.X,
			(int)Position.Y,
			RoomConstants.TileSize,
			RoomConstants.TileSize
		);

	public ISprite Sprite { get; set; }

	protected Tile(ISprite sprite, Vector2 position)
	{
		Sprite = sprite;
		Position = position;
	}

	public virtual void Update(GameTime delta)
	{
		Sprite.Update(delta);
	}

	public virtual void Draw(SpriteBatch spriteBatch)
	{
		Sprite.Draw(spriteBatch, Position, Color.White);
	}


	public virtual void Discontinue()
	{
		IsActive = false;
	}
}
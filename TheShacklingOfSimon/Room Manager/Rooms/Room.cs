using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Sprites.Factory;

namespace TheShacklingOfSimon.Room_Manager.Rooms
{
	public class Room
	{
		public TileMap TileMap { get; }

		public Room(SpriteFactory spriteFactory)
		{
			TileMap = new TileMap(spriteFactory);
		}

		public void Update(GameTime gameTime)
		{
			TileMap.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			TileMap.Draw(spriteBatch);
		}
	}
}
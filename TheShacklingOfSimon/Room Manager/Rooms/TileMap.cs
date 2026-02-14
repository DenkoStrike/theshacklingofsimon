using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Room_Manager;
using TheShacklingOfSimon.Sprites.Factory;

namespace TheShacklingOfSimon.Tiles
{
	public class TileMap
	{
		private readonly ITile[,] tiles;
		private readonly SpriteFactory spriteFactory;

		public TileMap(SpriteFactory spriteFactory)
		{
			this.spriteFactory = spriteFactory;

			tiles = new ITile[RoomConstants.GridWidth, RoomConstants.GridHeight];
			InitializeTiles();
		}

		private void InitializeTiles()
		{
			for (int x = 0; x < RoomConstants.GridWidth; x++)
			{
				for (int y = 0; y < RoomConstants.GridHeight; y++)
				{
					Vector2 position = new Vector2(
						x * RoomConstants.TileSize,
						y * RoomConstants.TileSize
					);

					if ((x + y) % 2 == 0)
					{
						var sprite = spriteFactory.CreateStaticSprite("rock");
						tiles[x, y] = new RockTile(sprite, position);
					}
					else
					{
						var sprite = spriteFactory.CreateStaticSprite("hole");
						tiles[x, y] = new HoleTile(sprite, position);
					}
				}
			}
		}

		public void Update(GameTime gameTime)
		{
			for (int x = 0; x < RoomConstants.GridWidth; x++)
			{
				for (int y = 0; y < RoomConstants.GridHeight; y++)
				{
					tiles[x, y].Update(gameTime);
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			for (int x = 0; x < RoomConstants.GridWidth; x++)
			{
				for (int y = 0; y < RoomConstants.GridHeight; y++)
				{
					tiles[x, y].Draw(spriteBatch);
				}
			}
		}
	}
}

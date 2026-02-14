using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Room_Manager;

namespace TheShacklingOfSimon.Tiles
{
	public class TileManager
	{
		private List<ITile> tiles;
		private int currentIndex;

		public ITile CurrentTile => tiles[currentIndex];

		public TileManager(List<ITile> tiles)
		{
			this.tiles = tiles;
			currentIndex = 0;
		}

		public void NextTile()
		{
			currentIndex = (currentIndex + 1) % tiles.Count;
		}

		public void PreviousTile()
		{
			currentIndex--;

			if (currentIndex < 0)
				currentIndex = tiles.Count - 1;
		}

		public void Update(GameTime gameTime)
		{
			CurrentTile.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			CurrentTile.Draw(spriteBatch);
		}
	}
}
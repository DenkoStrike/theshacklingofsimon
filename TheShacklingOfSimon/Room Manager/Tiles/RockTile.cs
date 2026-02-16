using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.Room_Manager.Tiles
{
	public class RockTile : Tile
	{
		public override bool IsSolid => true;
		public override bool BlocksProjectiles => true;
		public RockTile(ISprite sprite, Vector2 position)
			: base(sprite, position)
		{
		}
	}
}

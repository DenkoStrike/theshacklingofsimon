using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.Room_Manager.Tiles
{
	public class HoleTile : Tile
	{
		public override bool IsSolid => true;
		public override bool BlocksProjectiles => false;
		public HoleTile(ISprite sprite, Vector2 position)
			: base(sprite, position)
		{
		}
	}
}

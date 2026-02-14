using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.Room_Manager
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

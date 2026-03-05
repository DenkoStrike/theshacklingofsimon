using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.LevelHandler.Tiles.TileConstructor;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.LevelHandler.Tiles.Obstacles
{
    // Walkable hazard; collision system should apply damage on overlap
    public sealed class SpikeTile : Tile, ITriggerTile
    {
        public override bool BlocksGround => false;
        public override bool BlocksFly => false;
        public override bool BlocksProjectiles => false;

        public SpikeTile(ISprite sprite, Vector2 position) : base(sprite, position) { }

        public void OnIntersect(IEntity entity)
        {
            if (entity is IDamageable damageable)
            {
                damageable.TakeDamage(1);
            }
        }
    }
}
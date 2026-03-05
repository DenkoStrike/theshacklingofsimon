using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.LevelHandler.Tiles.Obstacles
{
    /// Invisible, indestructible wall used for borders. Blocks everything.
    public sealed class WallTile : Tile
    {
        public override bool BlocksGround => true;
        public override bool BlocksFly => true;
        public override bool BlocksProjectiles => true;

        public WallTile(ISprite sprite, Vector2 position) : base(sprite, position) { }

        // Invisible: don't draw anything
        public override void Draw(SpriteBatch spriteBatch) { }

        // No animation needed; avoid updating sprite work
        public override void Update(GameTime delta) { }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheShacklingOfSimon.Sprites.Products;

public interface ISprite
{
    // Basic Draw()
    public void Draw(SpriteBatch spriteBatch, Vector2 pos, Color color);

    // Draw scaled to fit a destination rectangle (useful for tiles/UI panels)
    public void Draw(SpriteBatch spriteBatch, Rectangle destination, Color color);

    // Full control Draw()
    public void Draw(SpriteBatch spriteBatch, Vector2 pos, 
        Color color, float rotation, Vector2 origin, 
        float scale, SpriteEffects effects, float layerDepth);
    public void Update(GameTime delta);
}
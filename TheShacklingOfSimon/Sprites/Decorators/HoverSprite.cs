using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Sprites.Decorators;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.UI;

public class HoverSprite : BaseDecoratedSprite
{
    private readonly Func<bool> _isHoveredOver;
    private readonly Color _normalColor;
    private readonly Color _hoverColor;

    public HoverSprite(ISprite baseSprite, Func<bool> isHoveredOver, Color normalColor, Color hoverColor) 
        : base(baseSprite)
    {
        _isHoveredOver = isHoveredOver;
        _normalColor = normalColor;
        _hoverColor = hoverColor;
    }

    public override void Update(GameTime delta)
    {
        BaseSprite.Update(delta);
    }

    public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
    {
        var coloring = _isHoveredOver() ? _hoverColor : _normalColor;
        BaseSprite.Draw(spriteBatch, position, coloring);
    }

    public override void Draw(SpriteBatch spriteBatch, Rectangle destination, Color color)
    {
        var coloring = _isHoveredOver() ? _hoverColor : _normalColor;
        BaseSprite.Draw(spriteBatch, destination, coloring);
    }

    public override void Draw(SpriteBatch spriteBatch, Vector2 pos, Color color, float rotation, Vector2 origin,
        float scale, SpriteEffects effects, float layerDepth)
    {
        var coloring = _isHoveredOver() ? _hoverColor : _normalColor;
        BaseSprite.Draw(spriteBatch, pos, coloring, rotation, origin, scale, effects, layerDepth);  
    }
}
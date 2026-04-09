using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.Sprites.Factory;

public static class SpriteDecoratorExtensions
{
    public static ISprite WithFade(this ISprite baseSprite, float startAlpha, float fadeSpeed)
    {
        return new FadingSprite(baseSprite, startAlpha, fadeSpeed);
    }
    
    public static ISprite WithDelay(this ISprite baseSprite, float delay)
    {
        return new DelayedSprite(baseSprite, delay);
    }
    
    // Can add more decorator instantiation methods here as more decorators are implemented
}
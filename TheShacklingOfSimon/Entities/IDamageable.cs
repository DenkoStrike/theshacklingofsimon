namespace TheShacklingOfSimon.Entities;

public interface IDamageable : IEntity
{
    /*
     * Inherits
     * Vector2 Position { get; }
     * Vector2 Velocity { get; }
     * bool IsActive { get; }
     * Rectangle Hitbox { get; }
     * ISprite Sprite { get; }
     * 
     * void Update(GameTime delta),
     * void Draw(SpriteBatch spriteBatch),
     * void Discontinue();
     *
     * To be implemented after Sprint 2:
     * void Interact(IEntity other)
     * 
     * from IEntity
     */
    
    int Health { get; }
    int MaxHealth { get; }

    void TakeDamage(int amt);
    void Heal(int amt);
}
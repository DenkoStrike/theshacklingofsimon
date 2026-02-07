using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public abstract class Entity
{
    // Common properties of *every* entity
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public float Health { get; set; }
    public bool IsActive { get; set; } = true;
    public Vector2 Hitbox { get; set; }

    // Abstract methods that every Entity-extending class will have to define separately
    public abstract void Update(GameTime delta);
    public abstract void Draw(SpriteBatch spriteBatch);

    // Methods every Entity-extending class will need, but can also be overridden.
    public virtual void TakeDamage(float amt)
    {
        Health -= amt;
        // Add code for invincibility frames and/or damage reaction
    }

    public virtual void Die()
    {
        IsActive = false;
        // Add code for death animation
    }
}
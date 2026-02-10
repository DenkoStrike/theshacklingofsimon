using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.Entities;
public interface IEntity
{
    // Common properties of *every* entity
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public bool IsActive { get; set; }
    public Rectangle Hitbox { get; set; }
    public ISprite Sprite { get; set; }
    
    void Update(GameTime delta);
    void Draw(SpriteBatch spriteBatch);
    void Discontinue();
    // void Interact(IEntity other);
}
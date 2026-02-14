using System.ComponentModel;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheShacklingOfSimon.Items;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.Entities;
public interface IPickup : IEntity
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
    
    IItem Item { get; set; }
    // if we are to allow weapon pickups, I suggest adding items that give weapons or having iweapon extend item
}
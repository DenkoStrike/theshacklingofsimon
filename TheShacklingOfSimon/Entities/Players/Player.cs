using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Projectiles;
using TheShacklingOfSimon.Sprites.Products;
using TheShacklingOfSimon.Weapons;

namespace TheShacklingOfSimon.Entities.Players;

public class Player : DamageableEntity, IPlayer
{
    public Inventory Inventory { get; private set; }
    public IWeapon CurrentWeapon { get; private set; }
    public IItem CurrentItem { get; private set; }
    
    public IPlayerHeadState CurrentHeadState { get; private set; }
    public IPlayerBodyState CurrentBodyState { get; private set; }
    
    
    public ISprite HeadSprite { get; private set; }
    /*
     * Sprite property inherited from IEntity
     * Sprite is the body sprite in this class.
     */ 

    public float MoveSpeedStat { get; private set; }
    public int DamageMultiplierStat { get; private set; }
    public Vector2 FacingDirection { get; private set; }
    private Vector2 _headOffset = new Vector2(0, -15);

    public Player(Vector2 startPosition)
    {
        // IEntity properties
        Position = startPosition;
        Velocity = Vector2.Zero;
        IsActive = true;
        // Arbitrarily sized hitbox of 20x20
        Hitbox = new Rectangle((int)startPosition.X, (int)startPosition.Y, 20, 20);
        // Not setting the initial Sprite in the constructor
        
        // IDamageable properties
        this.Health = 3;
        this.MaxHealth = 3;
        
        // Player properties
        this.Inventory = new Inventory();
        this.Inventory.AddWeapon(new BasicWeapon());
        this.Inventory.AddItem(new NoneItem());
        this.CurrentWeapon = Inventory.Weapons[0];
        this.CurrentItem = Inventory.Items[0];
        
        this.CurrentHeadState = new PlayerHeadIdleState();
        this.CurrentBodyState = new PlayerBodyIdleState();
        this.FacingDirection = new Vector2(0, -1);
    }

    public void AddWeaponToInventory(IWeapon weapon)
    {
        Inventory.AddWeapon(weapon);
    }

    public IWeapon RemoveWeaponFromInventory(int pos)
    {
        return Inventory.RemoveWeapon(pos);
    }
    
    public void AddItemToInventory(IItem item)
    {
        Inventory.AddItem(item);
    }

    public IItem RemoveItemFromInventory(int pos)
    {
        return Inventory.RemoveItem(pos);
    }

    public void EquipWeapon(int pos)
    {
        if (pos < Inventory.Weapons.Count)
        {
            CurrentWeapon = Inventory.Weapons[pos];
        }
    }

    public void EquipItem(int pos)
    {
        if (pos < Inventory.Items.Count)
        {
            CurrentItem = Inventory.Items[pos];
        }
    }

    public void Attack(Vector2 direction)
    {
        // No-op if no current weapon
        if (CurrentWeapon != null)
        {
            CurrentWeapon.Fire(Position, direction, new ProjectileStats(1.0f * DamageMultiplierStat, 5.0f));
        }
    }

    public void Move(Vector2 direction)
    {
        Velocity = direction * MoveSpeedStat;
    }

    public override void Update(GameTime delta)
    {
        CurrentHeadState.Update(delta, this);
        CurrentBodyState.Update(delta, this);
        
        float dt = (float)delta.ElapsedGameTime.TotalSeconds;
        Position += Velocity * dt;
        
        Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 20, 20);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Position);
    }

    public void ChangeHeadState(IPlayerHeadState newHeadState)
    {
        if (CurrentHeadState != newHeadState)
        {
            CurrentHeadState.Exit(this);
            CurrentHeadState = newHeadState;
            CurrentHeadState.Enter(this);
        }
    }

    public void ChangeBodyState(IPlayerBodyState newBodyState)
    {
        if (CurrentBodyState != newBodyState)
        {
            CurrentBodyState.Exit(this);
            CurrentBodyState = newBodyState;
            CurrentBodyState.Enter(this);
        }
    }
}
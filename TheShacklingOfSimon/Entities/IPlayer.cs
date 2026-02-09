using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Entities;

public interface IPlayer : IEntity, IDamageable
{
    Inventory Inventory { get; }
    IWeapon CurrentWeapon { get; }
    IItem CurrentItem { get; }
    IPlayerState CurrentState { get; }
    
    void EquipItem();
    void EquipWeapon();
    void Attack();
    void Move(Vector2 direction);

    void ChangeState(IPlayer newState);
    // Update() inherited from IEntity

}
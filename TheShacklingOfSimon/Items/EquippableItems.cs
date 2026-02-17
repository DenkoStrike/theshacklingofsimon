using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.Entities.Players;
using TheShacklingOfSimon.Items;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.Items;
public class EquippableItems : IItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IPlayer Player { get; }
    public int AttackBoost { get; }
    public int MaxHealthBoost { get; }
    public int MoveSpeedBoost { get; }
    
    public EquippableItems(IPlayer player)
    {
        Player = player;
    }
    
    public void ItemEffect()
    {
        Player.MoveSpeedStat += MoveSpeedBoost;
        Player.DamageMultiplierStat += AttackBoost;
        Player.MaxHealth += MaxHealthBoost;
    }
    public void ClearEffect()
    {
        Player.MoveSpeedStat -= MoveSpeedBoost;
        Player.DamageMultiplierStat -= AttackBoost;
        Player.MaxHealth -= MaxHealthBoost;
    }
}
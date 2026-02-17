using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.Entities.Players;
using TheShacklingOfSimon.Items;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.Items;
public class ConsumeableItems : IItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IPlayer Player { get; }
    public int HealthBoost { get; }

    public ConsumeableItems(IPlayer player)
    {
        Player = player;
    }
    
    public void ItemEffect()
    {
        Player.Heal(HealthBoost);
    }

}
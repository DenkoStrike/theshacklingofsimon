using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon.Items;

public class NoneItem : IItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IPlayer Player { get; }

    public NoneItem(IPlayer player)
    {
        Player = player;
    }

    public void ItemEffect()
    {
        // No-op
    }
}
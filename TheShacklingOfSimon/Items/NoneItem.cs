using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon.Items;

public class NoneItem : IItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IPlayer Player { get; }
    public ItemEffects Effects { get; }

    public NoneItem(IPlayer player)
    {
        Player = player;
    }

    public void Effect()
    {
        // No-op
    }
}
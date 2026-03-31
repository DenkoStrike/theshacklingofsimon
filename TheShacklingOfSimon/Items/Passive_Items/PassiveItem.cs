#region

using TheShacklingOfSimon.Entities.Players;
using TheShacklingOfSimon.StatusEffects;

#endregion

namespace TheShacklingOfSimon.Items.Passive_Items;
public class PassiveItem : IItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IPlayer Player { get; }
    public ItemEffects Effects { get; }

    
    public PassiveItem(IPlayer player)
    {
        Player = player;
    }
    
    public void Effect()
    {
        // TODO: use the StatusEffectManager instead of directly manipulating player stats
        Player.SetStat(StatType.DamageMultiplier, Player.GetStat(StatType.DamageMultiplier) + Effects.Attack);
        Player.Heal(Effects.Health);
        Player.MaxHealth += Effects.MaxHealth;
        Player.SetStat(StatType.MoveSpeed, Player.GetStat(StatType.MoveSpeed) + Effects.Speed);
    }
    public void ClearEffect()
    {
        // TODO: use the StatusEffectManager instead of directly manipulating player stats
        Player.SetStat(StatType.DamageMultiplier, Player.GetStat(StatType.DamageMultiplier - Effects.Attack));
        Player.MaxHealth -= Effects.MaxHealth;
        Player.SetStat(StatType.MoveSpeed, Player.GetStat(StatType.MoveSpeed) - Effects.Speed);
    }
}
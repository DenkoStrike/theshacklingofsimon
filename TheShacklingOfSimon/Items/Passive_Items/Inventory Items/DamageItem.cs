#region

using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.StatusEffects;
using TheShacklingOfSimon.StatusEffects.Implementations.Simple;
using TheShacklingOfSimon.StatusEffects.Templates;

#endregion

namespace TheShacklingOfSimon.Items.Passive_Items.Inventory_Items;

public class DamageItem : PassiveItem, IInventoryItem
{
    private readonly IStatusEffect _damageMultiplierEffect;
    
    public DamageItem(
        IDamageableEntity entity, 
        string name = "Brace", 
        string description = "Allows you to channel more power into shots", 
        float amt = 0.25f,
        float duration = float.MaxValue) 
        : base(name, description, entity)
    {
        _damageMultiplierEffect = new DamageMultiplierEffect(
            Name, 
            Entity, 
            amt * Entity.GetStat(StatType.DamageMultiplier),
            duration
        );
    }
    public override bool ApplyEffect()
    {
        Entity.EffectManager.AddPermanentEffect(_damageMultiplierEffect);
        return true;
    }
    
    public override void ClearEffect()
    {
        Entity.EffectManager.ClearPermanentEffect(_damageMultiplierEffect);
    }
}
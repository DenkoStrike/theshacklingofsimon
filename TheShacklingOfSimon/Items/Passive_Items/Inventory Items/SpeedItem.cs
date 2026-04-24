#region

using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.StatusEffects;
using TheShacklingOfSimon.StatusEffects.Implementations.Simple;
using TheShacklingOfSimon.StatusEffects.Templates;

#endregion

namespace TheShacklingOfSimon.Items.Passive_Items.Inventory_Items;

public class SpeedItem : PassiveItem, IInventoryItem
{
    private readonly IStatusEffect _moveSpeedEffect;
    
    public SpeedItem(
        IDamageableEntity entity, 
        string name = "Running Boots", 
        string description = "Increases speed by 25%", 
        float amt = 0.25f,
        float duration = float.MaxValue) 
        : base(name, description, entity)
    {
        _moveSpeedEffect = new MoveSpeedEffect(
            Name, 
            Entity, 
            amt * Entity.GetStat(StatType.MoveSpeed), 
            duration
        );
    }
    
    public override bool ApplyEffect()
    {
        Entity.EffectManager.AddPermanentEffect(_moveSpeedEffect);
        return true;
    }

    public override void ClearEffect()
    {
        Entity.EffectManager.ClearPermanentEffect(_moveSpeedEffect);
    }
}
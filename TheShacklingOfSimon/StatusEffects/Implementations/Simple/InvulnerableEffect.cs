using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.StatusEffects.Templates;

namespace TheShacklingOfSimon.StatusEffects.Implementations.Simple;

public class InvulnerableEffect : SimpleStatusEffect
{
    public InvulnerableEffect(string name, IDamageableEntity owner, float duration)
        : base(name, EffectType.InvulnerabilityDuration, owner, 1f, duration)
    {
    }

    public override void OnApply()
    {
        Timer = 0.0f;
        float currentCount = Owner.GetStat(StatType.InvulnerableCount);
        float newCount = currentCount + Strength;

        Difference = currentCount - newCount;
        Owner.SetStat(StatType.InvulnerableCount, newCount);
    }
    
    public override void OnRemove()
    {
        Owner.SetStat(StatType.InvulnerableCount, Owner.GetStat(StatType.InvulnerableCount) + Difference);
    }

    public override void Merge(IStatusEffect other)
    {
        if (other is not InvulnerableEffect castedOther) return;
        
        // Strength doesn't do anything for this effect, only duration
        Duration += castedOther.Duration;
    }

    public override IStatusEffect Clone(IDamageableEntity newTarget)
    {
        return new InvulnerableEffect(Name, newTarget, Duration);   
    }
}
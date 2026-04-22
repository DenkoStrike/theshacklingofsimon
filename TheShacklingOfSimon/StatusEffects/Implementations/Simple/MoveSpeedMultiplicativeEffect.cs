using System;
using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.StatusEffects.Templates;

namespace TheShacklingOfSimon.StatusEffects.Implementations.Simple;

public class MoveSpeedMultiplicativeEffect : SimpleStatusEffect
{
    public MoveSpeedMultiplicativeEffect(string name, EffectType type, IDamageableEntity owner, float strength, float duration)
        : base(name, type, owner, strength, duration)
    {
    }

    public override void OnApply()
    {
        Timer = 0.0f;
        float currentSpeed = Owner.GetStat(StatType.MoveSpeedMultiplier);
        float newSpeed = currentSpeed + Strength;

        Difference = currentSpeed - newSpeed;
        Owner.SetStat(StatType.MoveSpeedMultiplier, newSpeed);
        Console.WriteLine($"Current speed: {currentSpeed}, new speed: {newSpeed}");
    }

    public override void OnRemove()
    {
        Owner.SetStat(StatType.MoveSpeedMultiplier, Owner.GetStat(StatType.MoveSpeedMultiplier) + Difference);
    }

    public override void Merge(IStatusEffect other)
    {
        if (other is not MoveSpeedMultiplicativeEffect castedOther) return;
        Strength += castedOther.Strength;
        Duration = Math.Max(Duration, castedOther.Duration);
    }
    
    public override IStatusEffect Clone(IDamageableEntity newTarget)
    {
        return new MoveSpeedMultiplicativeEffect(Name, Type, newTarget, Strength, Duration);
    }
}
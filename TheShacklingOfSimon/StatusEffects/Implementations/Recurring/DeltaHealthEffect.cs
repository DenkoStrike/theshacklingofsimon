using System;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities;

namespace TheShacklingOfSimon.StatusEffects.Implementations;

public class DeltaHealthEffect : RecurringStatusEffect
{
    public DeltaHealthEffect(string name, IDamageableEntity owner, float tickStrength, float duration, float numTicks) 
        : base(name, owner, tickStrength, duration, numTicks)
    {
    }

    public override void Update(GameTime delta)
    {
        base.Update(delta);

        if (PreviousApplicationTime >= TickDuration)
        {
            Owner.TakeDamage((int)Strength);
        }
    }

    public override void Merge(IStatusEffect other)
    {
        if (other is not DeltaHealthEffect otherCasted) return;

        Strength += otherCasted.Strength;
        Duration = Math.Max(Duration, otherCasted.Duration);
    }
}
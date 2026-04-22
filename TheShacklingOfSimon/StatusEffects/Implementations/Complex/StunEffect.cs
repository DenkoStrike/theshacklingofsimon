#region

using System.Collections.Generic;
using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.StatusEffects.Implementations.Simple;
using TheShacklingOfSimon.StatusEffects.Templates;

#endregion

namespace TheShacklingOfSimon.StatusEffects.Implementations.Complex;

public class StunEffect : ComplexStatusEffect
{
    public StunEffect(string name, EffectType type, IDamageableEntity owner, float moveStunDuration, float disarmDuration) 
        : base(name, type, owner)
    {
        ComponentEffects.Add(
            new MoveSpeedMultiplicativeEffect(
                Name, 
                EffectType.MoveSpeed, 
                Owner, 
                -1f,
                moveStunDuration
            )
        );
        ComponentEffects.Add(
            new PrimaryCooldownEffect(
                Name,
                EffectType.PrimaryCooldown,
                Owner,
                disarmDuration,
                disarmDuration
            )
        );
        ComponentEffects.Add(
            new SecondaryCooldownEffect(
                Name, 
                EffectType.SecondaryCooldown, 
                Owner, 
                disarmDuration, 
                disarmDuration
            )
        );
    }

    // For cloning
    private StunEffect(string name, EffectType type, IDamageableEntity owner, List<IStatusEffect> components) 
        : base(name, type, owner)
    {
        ComponentEffects = components;
    }

    public override void Merge(IStatusEffect other)
    {
        if (other is not StunEffect castedOther) return;
        for (int i = 0; i < ComponentEffects.Count; i++)
        {
            if (i >= castedOther.ComponentEffects.Count) break; // safety, although likely unneeded.
            ComponentEffects[i].Merge(castedOther.ComponentEffects[i]);
        }
    }

    public override IStatusEffect Clone(IDamageableEntity newTarget)
    {
        List<IStatusEffect> components = new List<IStatusEffect>();
        foreach (var effect in ComponentEffects)
        {
            components.Add(effect.Clone(newTarget));
        }
        
        return new StunEffect(Name, Type, newTarget, components);
    }
}
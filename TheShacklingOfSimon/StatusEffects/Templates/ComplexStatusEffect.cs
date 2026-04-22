using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities;

namespace TheShacklingOfSimon.StatusEffects.Templates;

public abstract class ComplexStatusEffect : IStatusEffect
{
    public string Name { get; protected set; }
    public EffectType Type { get; protected set; }
    public bool IsFinished { get; private set; }
    public IDamageableEntity Owner { get; private set; }
    public float Duration { get; protected set; }
    
    protected List<IStatusEffect> ComponentEffects;

    protected ComplexStatusEffect(string name, EffectType type, IDamageableEntity owner)
    {
        Name = name;
        Type = type;
        IsFinished = false;
        Owner = owner;
        ComponentEffects = new List<IStatusEffect>();
    }

    public virtual void OnApply()
    {
        foreach (var effect in ComponentEffects)
        {
            effect.OnApply();
        }
    }

    public virtual void OnRemove()
    {
        foreach (var effect in ComponentEffects)
        {
            effect.OnRemove();
        }
    }

    public virtual void Update(GameTime delta)
    {
        foreach (var effect in ComponentEffects)
        {
            effect.Update(delta);
        }
    }

    public abstract void Merge(IStatusEffect other);
    public abstract IStatusEffect Clone(IDamageableEntity newTarget);
}
namespace TheShacklingOfSimon.StatusEffects.Templates;

public enum EffectType
{
    // Simple effects
    DamageMultiplier,
    InvulnerabilityDuration,
    MaxHealth,
    MoveSpeed,
    MoveSpeedMultiplier,
    PrimaryCooldown,
    SecondaryCooldown,
    ProjectileSpeedMultiplier,
    
    // Recurring effects
    HealthRegen,
    Poison,
    OnFire,
    
    // Complex
    Stun,
    Confusion
}
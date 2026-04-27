#region

using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.Sounds;
using TheShacklingOfSimon.StatusEffects.Implementations.Simple;

#endregion

namespace TheShacklingOfSimon.Items.Active_Items;

public class InvincibilityItem : ActiveItem, IInventoryItem
{
    private readonly string _sfx;
    private float _timer;
    private readonly float _cooldownDuration;
    private bool _buffActive;

    private readonly float _buffDuration;

    public InvincibilityItem(
        IDamageableEntity entity,
        float buffDuration = 5.0f,
        float cooldownDuration = 10.0f)
        : base(entity)
    {
        _cooldownDuration = cooldownDuration;

        Name = "Invincibility";
        Description = "Become Invincible.";
        _sfx = SoundManager.Instance.AddSFX("items","Powerup2");
        
        _buffDuration = buffDuration;
     
    }

    public override void Update(GameTime gameTime)
    {
        if (!_buffActive) return;
        _timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_timer <= 0f)
        {
            _buffActive = false;
        }
    }

    public override bool ApplyEffect()
    {
        if (_buffActive) return false;
        _buffActive = true;
        _timer = _cooldownDuration;
        
        // Create effects here to avoid issues with the effects being applied to the wrong entity
        var invincibleEffect = new InvulnerableEffect(
            Name, 
            Entity,
            _buffDuration
        );
        Entity.EffectManager.AddTemporaryEffect(invincibleEffect);
        SoundManager.Instance.PlaySFX(_sfx);
        return true;
    }
}
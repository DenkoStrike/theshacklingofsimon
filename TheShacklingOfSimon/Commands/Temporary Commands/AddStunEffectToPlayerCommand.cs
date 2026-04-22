using TheShacklingOfSimon.Entities.Players;
using TheShacklingOfSimon.StatusEffects.Implementations.Complex;
using TheShacklingOfSimon.StatusEffects.Templates;

namespace TheShacklingOfSimon.Commands.Temporary_Commands;

public class AddStunEffectToPlayerCommand : ICommand
{
    private readonly IPlayer _player;
    private readonly StunEffect _effect;

    public AddStunEffectToPlayerCommand(IPlayer player)
    {
        _player = player;
        _effect = new StunEffect("Stunned!", EffectType.Stun, _player, 2f, 3f);
    }

    public void Execute()
    {
        _player.EffectManager.AddEffect(_effect);
    }
}
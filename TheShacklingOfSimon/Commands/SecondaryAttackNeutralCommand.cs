using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon.Commands;

public class SecondaryAttackNeutralCommand : ICommand
{
    private IPlayer _player;

    public SecondaryAttackNeutralCommand(IPlayer player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.RegisterSecondaryAttackInput(new Vector2(0, 0));
    }
}
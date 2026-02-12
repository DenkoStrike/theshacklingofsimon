using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon.Commands;

public class AttackLeftCommand : ICommand
{
    private IPlayer _player;

    public AttackLeftCommand(IPlayer player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.RegisterPrimaryAttackInput(new Vector2(-1, 0));
    }
}
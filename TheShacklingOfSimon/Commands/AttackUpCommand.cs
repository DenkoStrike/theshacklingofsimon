using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon.Commands;

public class AttackUpCommand : ICommand
{
    private readonly IPlayer _player;

    public AttackUpCommand(IPlayer player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.RegisterPrimaryAttackInput(new Vector2(0, -1));
    }
}
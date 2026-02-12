using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon.Commands;

public class AttackDownCommand : ICommand
{
    private readonly IPlayer _player;

    public AttackDownCommand(IPlayer player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.RegisterPrimaryAttackInput(new Vector2(0, 1));
    }
}
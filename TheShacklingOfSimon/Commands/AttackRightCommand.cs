using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon.Commands;

public class AttackRightCommand : ICommand
{
    private IPlayer _player;

    public AttackRightCommand(IPlayer player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.Attack(new Vector2(1, 0));
    }
}
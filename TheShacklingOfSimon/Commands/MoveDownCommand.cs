using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon.Commands;

public class MoveDownCommand : ICommand
{
    private readonly Player _player;

    public MoveDownCommand(Player player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.Move(new Vector2(0, 1));
    }
}
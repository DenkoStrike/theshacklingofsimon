using TheShacklingOfSimon.Entities.Players;
using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Commands;


public class MoveUpCommand : ICommand
{
    private readonly IPlayer _player;
    
    public MoveUpCommand(IPlayer player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.Move(new Vector2(0, -1));
    }
}
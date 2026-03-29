#region

using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

#endregion

namespace TheShacklingOfSimon.Commands.PlayerMovement;

public class MoveLeftCommand : ICommand
{
    private readonly IPlayer _player;
    
    public MoveLeftCommand(IPlayer player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.InputBuffer.AddMovement(new Vector2(-1, 0));
    }
}
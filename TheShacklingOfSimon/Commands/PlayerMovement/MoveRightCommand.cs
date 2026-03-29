#region

using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

#endregion

namespace TheShacklingOfSimon.Commands.PlayerMovement;

public class MoveRightCommand : ICommand
{
    private readonly IPlayer _player;

    public MoveRightCommand(IPlayer playerWithTwoSprites)
    {
        _player = playerWithTwoSprites;
    }

    public void Execute()
    {
        _player.InputBuffer.AddMovement(new Vector2(1, 0));
    }
}
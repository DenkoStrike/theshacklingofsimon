using TheShacklingOfSimon.Entities.Players;
using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Commands;

public class MoveRightCommand : ICommand
{
    private readonly IPlayer _playerWithTwoSprites;

    public MoveRightCommand(PlayerWithTwoSprites playerWithTwoSprites)
    {
        _playerWithTwoSprites = playerWithTwoSprites;
    }

    public void Execute()
    {
        _playerWithTwoSprites.RegisterMoveInput(new Vector2(1, 0));
    }
}
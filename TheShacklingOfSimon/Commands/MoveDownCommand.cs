using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon.Commands;

public class MoveDownCommand : ICommand
{
    private readonly IPlayer _playerWithTwoSprites;

    public MoveDownCommand(PlayerWithTwoSprites playerWithTwoSprites)
    {
        _playerWithTwoSprites = playerWithTwoSprites;
    }

    public void Execute()
    {
        _playerWithTwoSprites.RegisterMoveInput(new Vector2(0, 1));
    }
}
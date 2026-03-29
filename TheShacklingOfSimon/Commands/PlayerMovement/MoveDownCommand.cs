#region

using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

#endregion

namespace TheShacklingOfSimon.Commands.PlayerMovement;

public class MoveDownCommand : ICommand
{
    private readonly IPlayer _player;

    public MoveDownCommand(IPlayer player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.InputBuffer.AddMovement(new Vector2(0, 1));
    }
}
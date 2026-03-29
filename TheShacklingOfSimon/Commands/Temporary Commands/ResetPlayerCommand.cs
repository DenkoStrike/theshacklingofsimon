#region

using System;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

#endregion

namespace TheShacklingOfSimon.Commands.Temporary_Commands;

public sealed class ResetPlayerCommand : ICommand
{
    private readonly IPlayer _player;
    private readonly Vector2 _startPosition;
    private readonly Action _afterReset;

    public ResetPlayerCommand(IPlayer player, Vector2 startPosition, Action afterReset)
    {
        _player = player ?? throw new ArgumentNullException(nameof(player));
        _startPosition = startPosition;
        _afterReset = afterReset ?? throw new ArgumentNullException(nameof(afterReset));
    }

    public void Execute()
    {
        _player.Reset(_startPosition);
        _afterReset();
    }
}
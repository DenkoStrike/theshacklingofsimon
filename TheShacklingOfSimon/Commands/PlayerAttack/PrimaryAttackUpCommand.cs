#region

using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Players;

#endregion

namespace TheShacklingOfSimon.Commands.PlayerAttack;

public class PrimaryAttackUpCommand : ICommand
{
    private readonly IPlayer _player;

    public PrimaryAttackUpCommand(IPlayer player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.InputBuffer.AddPrimaryAttack(new Vector2(0, -1));
    }
}
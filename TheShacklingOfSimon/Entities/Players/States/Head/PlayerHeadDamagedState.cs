#region

using Microsoft.Xna.Framework;

#endregion

namespace TheShacklingOfSimon.Entities.Players.States.Head;

public class PlayerHeadDamagedState : IPlayerHeadState
{
    private readonly PlayerWithTwoSprites _player;

    public PlayerHeadDamagedState(PlayerWithTwoSprites player)
    {
        _player = player;
    }
    
    public void Enter()
    {
        _player.SpritesManager.Head = null;
    }

    public void Exit()
    {
        /*
         * No-op for now
         * Could use this later for stopping any sounds related to moving (e.g., walking)
         */
    }

    public void Update(GameTime delta)
    {
    }

    public void HandlePrimaryAttack(Vector2 direction, float stateDuration)
    {
    }

    public void HandleSecondaryAttack(Vector2 direction, float stateDuration)
    {
    }
}
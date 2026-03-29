#region

using Microsoft.Xna.Framework;

#endregion

namespace TheShacklingOfSimon.Entities.Players.States.Body;

public interface IPlayerBodyState : IPlayerState
{
    /*
     * Inherits
     * void Enter(),
     * void Exit(),
     * void Update(GameTime delta)
     * from IPlayerState
     */
    
    void HandleMovement(Vector2 direction, float frameDuration);
}
using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Entities.Players.States.Head;

public interface IPlayerHeadState : IPlayerState
{
    /*
     * Inherits
     * void Enter(),
     * void Exit(),
     * void Update(GameTime delta)
     * from IPlayerState
     */
    
    void HandleAttack(Vector2 direction, float stateDuration);
    void HandleAttackSecondary(Vector2 direction, float stateDuration);
}
using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Entities.Players.SeparateStates.Head;

public interface IPlayerHeadState
{
    void Enter();
    void Exit();
    void Update(GameTime delta);
    void HandleAttack(Vector2 direction, float stateDuration);
    void HandleAttackSecondary(Vector2 direction, float stateDuration);
}
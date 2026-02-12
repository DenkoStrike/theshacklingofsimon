using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Entities.Players.SeparateStates.Body;

public interface IPlayerBodyState
{
    void Enter();
    void Exit();
    void Update(GameTime delta);
    void HandleMovement(Vector2 direction);
}
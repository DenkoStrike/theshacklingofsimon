using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheShacklingOfSimon.Entities.Players.States;

public interface IPlayerHeadState
{
    void Update(GameTime delta);
    void Enter();
    void Exit();
    void HandleAttack(Vector2 direction);
    void HandleAttackSecondary(Vector2 direction);
}
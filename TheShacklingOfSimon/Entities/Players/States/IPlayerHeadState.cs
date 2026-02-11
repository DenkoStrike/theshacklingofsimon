using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheShacklingOfSimon.Entities.Players.States;

public interface IPlayerHeadState
{
    void Update(IPlayer player, GameTime delta);
    void Draw(SpriteBatch spriteBatch, Vector2 position);
    void Enter(IPlayer player);
    void Exit(IPlayer player);
    void HandleAttack(IPlayer player, Vector2 direction);
    void HandleAttackSecondary(IPlayer player, Vector2 direction);
}
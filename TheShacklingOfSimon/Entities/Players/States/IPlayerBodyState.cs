using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheShacklingOfSimon.Entities.Players.States;

public interface IPlayerBodyState
{
    void Update(IPlayer player, GameTime delta);
    void Draw(SpriteBatch spriteBatch, Vector2 position);
    void Enter(IPlayer player);
    void Exit(IPlayer player);
    void HandleMovement(IPlayer player, Vector2 direction);
}
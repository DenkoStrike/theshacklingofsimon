using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Entities.Players.States;

public interface IPlayerState
{
    void Enter();
    void Exit();
    void Update(GameTime delta);
}
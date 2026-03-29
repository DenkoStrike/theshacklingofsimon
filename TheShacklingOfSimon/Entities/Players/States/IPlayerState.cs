#region

using Microsoft.Xna.Framework;

#endregion

namespace TheShacklingOfSimon.Entities.Players.States;

public interface IPlayerState
{
    void Enter();
    void Exit();
    void Update(GameTime delta);
}
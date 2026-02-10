using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Entities.Players;

public interface IPlayerHeadState
{
    public void Update(GameTime delta, IPlayer player);
    public void Enter(IPlayer player);
    public void Exit(IPlayer player);
    
}
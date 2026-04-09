#region

using TheShacklingOfSimon.Entities.Enemies.EnemyTypes;
using Vector2 = Microsoft.Xna.Framework.Vector2;

#endregion

namespace TheShacklingOfSimon.Entities.Enemies.EnemyBehaviours.MovementBehaviours;

public interface IMovementBehavior
{
    Vector2 GetMovement(BaseEnemy enemy, float dt, Vector2 targetDirection);
}
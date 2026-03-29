#region

using Microsoft.Xna.Framework;

#endregion

namespace TheShacklingOfSimon.Entities;

public interface ITargetProvider
{
    Vector2 GetPosition();
}
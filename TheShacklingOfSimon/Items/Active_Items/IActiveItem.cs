using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Items;

/// <summary>
/// Marker interface with additional functionality for active items
/// </summary>
public interface IActiveItem : IItem
{
    void ClearEffect();
    void Update(GameTime delta);
}
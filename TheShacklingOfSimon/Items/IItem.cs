using TheShacklingOfSimon.Entities;

namespace TheShacklingOfSimon.Items;

/// <summary>
/// The base interface for all items. Base set of functionality.
/// </summary>
public interface IItem
{
    string Name { get; }
    string Description { get; }
    IDamageableEntity Entity { get; }
    
    void ApplyEffect();
}
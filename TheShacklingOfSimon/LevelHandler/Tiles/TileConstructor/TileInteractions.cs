using TheShacklingOfSimon.Entities;

namespace TheShacklingOfSimon.LevelHandler.Tiles.TileConstructor
{
    // Tile can be affected by an explosion (bomb)
    public interface IBombableTile
    {
        void OnExplode();
    }

    // Tile can be affected by a projectile hit/overlap
    public interface IProjectileAffectableTile
    {
        void OnProjectileHit();
    }

    // Tile triggers an effect when an entity overlaps it (spikes, hazards)
    public interface ITriggerTile
    {
        void OnIntersect(IEntity entity);
    }
}
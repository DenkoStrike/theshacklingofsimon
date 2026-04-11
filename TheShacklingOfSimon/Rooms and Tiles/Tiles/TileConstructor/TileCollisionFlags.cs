#region

using System;

#endregion

namespace TheShacklingOfSimon.Rooms_and_Tiles.Tiles.TileConstructor
{
    // I group the tile blocking rules together so each tile does not repeat 3 separate properties.
    [Flags]
    public enum TileCollisionFlags
    {
        None = 0,
        BlocksGround = 1,
        BlocksFly = 2,
        BlocksProjectiles = 4
    }
}
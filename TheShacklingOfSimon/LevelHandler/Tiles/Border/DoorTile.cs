using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities.Enemies;
using TheShacklingOfSimon.Entities.Players;
using TheShacklingOfSimon.LevelHandler.Rooms.RoomManager;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.LevelHandler.Tiles.Border
{
    public sealed class DoorTile : Tile
    {
        private IRoomNavigator roomNavigator;

        protected override TileCollisionFlags CollisionFlags => TileCollisionFlags.BlocksProjectiles;

        public string ToRoom { get; }
        public Point SpawnGrid { get; }
        public DoorSide Side { get; }

        public DoorTile(
            ISprite sprite,
            Vector2 position,
            string toRoom,
            Point spawnGrid,
            DoorSide side)
            : base(sprite, position)
        {
            ToRoom = toRoom ?? "";
            SpawnGrid = spawnGrid;
            Side = side;
        }

        public void BindNavigator(IRoomNavigator navigator)
        {
            roomNavigator = navigator;
        }

        public override void OnCollision(IPlayer player)
        {
            if (player == null || roomNavigator == null) return;

            roomNavigator.RequestRoomSwitch(ToRoom, SpawnGrid, player);
        }

        public override void OnCollision(IEnemy enemy)
        {
            if (enemy == null || !IsActive) return;

            ResolveEntityCollision(enemy);
        }
    }
}
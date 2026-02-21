using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TheShacklingOfSimon.Level_Handler.Rooms.Room_Class;
using TheShacklingOfSimon.Level_Handler.Tiles;
using TheShacklingOfSimon.Level_Handler.Rooms;
using TheShacklingOfSimon.Sprites.Factory;

namespace TheShacklingOfSimon.Commands.Tile_Commands_and_temporary_Manager
{
    // Temporary class for cycling through tiles (debug / testing)
    public class TileManager
    {
        private readonly List<ITile> tiles;
        private int currentIndex;

        public TileManager(SpriteFactory spriteFactory)
        {
            tiles = new List<ITile>();

            Vector2 center = new Vector2(400, 300);

            // Treat tile Position as TOP-LEFT; convert preview center -> tile top-left
            Vector2 tileTopLeft = center - new Vector2(RoomConstants.TileSize / 2f, RoomConstants.TileSize / 2f);

            var rockSprite = spriteFactory.CreateStaticSprite("images/Rocks");
            var spikeSprite = spriteFactory.CreateStaticSprite("images/Spikes");

            // Use the exact key name your JSON provides (example: "Fire" or "images/Fire")
            var fireSprite = spriteFactory.CreateAnimatedSprite("images/Fire", 0.12f);
            if (fireSprite == null)
                throw new InvalidOperationException("Animated sprite 'images/Fire' was not loaded into SpriteFactory.");

            tiles.Add(new RockTile(rockSprite, tileTopLeft));
            tiles.Add(new SpikeTile(spikeSprite, tileTopLeft));
            tiles.Add(new FireTile(fireSprite, tileTopLeft));

            currentIndex = 0;
        }

        public void NextTile()
        {
            currentIndex = (currentIndex + 1) % tiles.Count;
        }

        public void PreviousTile()
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = tiles.Count - 1;
        }

        public void Update(GameTime gameTime)
        {
            tiles[currentIndex].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            tiles[currentIndex].Draw(spriteBatch);
        }
    }
}
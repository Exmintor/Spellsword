using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class World
    {
        private Tile[,] tileMap;
        public int xSize;
        public int ySize;
        public Vector2 StartingLocation { get; set; }
        private Vector2 currentLocation;
        Texture2D tileSprite;

        public World(Point mapSize, Texture2D tileSprite)
        {
            StartingLocation = new Vector2(0, 0);
            currentLocation = StartingLocation;
            this.xSize = mapSize.X;
            this.ySize = mapSize.Y;
            this.tileSprite = tileSprite;
            PopulateTileMap();
        }

        private void PopulateTileMap()
        {
            tileMap = new Tile[xSize, ySize];
            for (int i = 0; i < xSize; i++)
            {
                currentLocation.Y = StartingLocation.Y;
                for (int j = 0; j < ySize; j++)
                {
                    tileMap[i, j] = new Tile(tileSprite, currentLocation);
                    currentLocation.Y += tileSprite.Height + 1;
                }
                currentLocation.X += tileSprite.Width + 1;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            UpdateTileLocation();
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    tileMap[i, j].Draw(spriteBatch);
                }
            }
        }

        private void UpdateTileLocation()
        {
            currentLocation = StartingLocation;
            for (int i = 0; i < xSize; i++)
            {
                currentLocation.Y = StartingLocation.Y;
                for (int j = 0; j < ySize; j++)
                {
                    tileMap[i, j].Location = currentLocation;
                    currentLocation.Y += tileSprite.Height + 1;
                }
                currentLocation.X += tileSprite.Width + 1;
            }
        }

        public Vector2 GetTileLocation(Point tileNumber)
        {
            if (tileNumber.X < xSize && tileNumber.X >= 0 && tileNumber.Y < ySize && tileNumber.Y >= 0)
            {
                return tileMap[tileNumber.X, tileNumber.Y].Location;
            }
            return Vector2.Zero;
        }

        public bool IsOccupied(Point tileNumber)
        {
            if (tileNumber.X < xSize && tileNumber.X >= 0 && tileNumber.Y < ySize && tileNumber.Y >= 0)
            {
                if (tileMap[tileNumber.X, tileNumber.Y].Occupant != null)
                {
                    return true;
                }
            }
            return false;
        }

        public WorldEntity GetEntityAtLocation(Point location)
        {
            return tileMap[location.X, location.Y].Occupant;
        }

        public void RegisterEntity(WorldEntity toRegister, Point newLocation)
        {
            tileMap[newLocation.X, newLocation.Y].Occupant = toRegister;
        }
        public void UnregisterEntity(Point oldLocation)
        {
            tileMap[oldLocation.X, oldLocation.Y].Occupant = null;
        }

        public bool IsOnMap(Point point)
        {
            if (point.X < xSize && point.X >= 0 && point.Y < ySize && point.Y >= 0)
            {
                return true;
            }
            return false;
        }

        public Vector2 GetStartingMiddle()
        {
            return GetTileLocation(new Point(5, 5));
        }
    }
}

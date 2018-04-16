using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public static class Parameters
    {
        // Player movement
        public static float playerMovementSpeed = 0.12f;
        public static float pixelsMovedPerFrame = 16.5f;

        // Game size
        public static int numTiles = 11;
        public static int tileSize = 32;

        // Battle Location Data
        public static Vector2 battlePlayerLocation = new Vector2(50, 90);
        public static Vector2 battlePlayerHealthOffset = new Vector2(5, -20);
        public static Vector2 battlePlayerStatusOffset = new Vector2(-40, 0);

        public static Vector2 battleEnemyLocation = new Vector2(180, 80);
        public static Vector2 battleEnemyHealthOffset = new Vector2(10, -20);
        public static Vector2 battleEnemyStatusOffset = new Vector2(40, 0);

        public static Vector2 statusEffectOffset = new Vector2(0, 20);

        //Battle menu location data
        public static Vector2 battleCommandXOffset = new Vector2(90, 0);
        public static Vector2 battleCommandYOffset = new Vector2(0, 30);
        public static Vector2 arrowOffset = new Vector2(-8, 0);
    }
}

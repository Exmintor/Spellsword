using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Tile : Sprite
    {
        public WorldEntity Occupant { get; set; }

        public Tile(Texture2D sprite, Vector2 location)
        {
            Occupant = null;

            this.Location = location;
            this.CurrentSprite = sprite;
        }
    }
}

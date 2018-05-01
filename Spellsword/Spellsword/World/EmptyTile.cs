using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class EmptyTile : WorldEntity
    {
        public EmptyTile(SpellswordGame game, World world, Point pointLocation)
        {
            this.CurrentSprite = game.Content.Load<Texture2D>("EmptyTile");
            this.Location = world.GetTileLocation(pointLocation);
        }
    }
}

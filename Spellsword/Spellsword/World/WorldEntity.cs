using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class WorldEntity : Sprite
    {
        protected SpellswordGame game;
        protected World gameWorld;
        protected Entity thisEntity;
    }
}

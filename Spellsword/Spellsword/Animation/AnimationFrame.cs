using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class AnimationFrame
    {
        public Texture2D ThisFrame { get; private set; }
        public AnimationFrame NextFrame { get; set; }

        public AnimationFrame(Texture2D thisFrame)
        {
            this.ThisFrame = thisFrame;
            this.NextFrame = null;
        }
    }
}

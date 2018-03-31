using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Animation
    {
        public AnimationFrame StartFrame { get; protected set; }
        public AnimationFrame CurrentFrame { get; protected set; }

        public virtual void Update(Sprite spriteToAnimate)
        {
            if(CurrentFrame.ThisFrame != null)
            {
                spriteToAnimate.CurrentSprite = CurrentFrame.ThisFrame;
            }
            if (this.CurrentFrame.NextFrame != null)
            {
                this.CurrentFrame = CurrentFrame.NextFrame;
            }
        }

        public Texture2D GetCurrentFrame()
        {
            return CurrentFrame.ThisFrame;
        }
    }
}

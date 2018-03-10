using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spellsword.PlayerFolder.Animations
{
    public class WalkLeftAnimation : Animation
    {
        private AnimationFrame stillFrame;
        private AnimationFrame walkingFrame;
        public WalkLeftAnimation(Game game)
        {
            stillFrame = new AnimationFrame(game.Content.Load<Texture2D>("LeftStill"));
            walkingFrame = new AnimationFrame(game.Content.Load<Texture2D>("LeftWalking"));
            stillFrame.NextFrame = walkingFrame;
            walkingFrame.NextFrame = stillFrame;

            this.StartFrame = walkingFrame;
            this.CurrentFrame = StartFrame;
        }
    }
}

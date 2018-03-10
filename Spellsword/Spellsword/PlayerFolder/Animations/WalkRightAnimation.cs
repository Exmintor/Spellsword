using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spellsword.PlayerFolder.Animations
{
    public class WalkRightAnimation : Animation
    {
        private AnimationFrame stillFrame;
        private AnimationFrame walkingFrame;
        public WalkRightAnimation(Game game)
        {
            stillFrame = new AnimationFrame(game.Content.Load<Texture2D>("RightStill"));
            walkingFrame = new AnimationFrame(game.Content.Load<Texture2D>("RightWalking"));
            stillFrame.NextFrame = walkingFrame;
            walkingFrame.NextFrame = stillFrame;

            this.StartFrame = walkingFrame;
            this.CurrentFrame = StartFrame;
        }
    }
}

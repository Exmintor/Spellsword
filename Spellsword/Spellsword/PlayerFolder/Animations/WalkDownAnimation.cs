using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword.PlayerFolder.Animations
{
    public class WalkDownAnimation : Animation
    {
        AnimationFrame stillFrameOne;
        AnimationFrame walkingFrameLeft;
        AnimationFrame stillFrameTwo;
        AnimationFrame walkingFrameRight;

        public WalkDownAnimation(Game game)
        {
            stillFrameOne = new AnimationFrame(game.Content.Load<Texture2D>("ForwardStill"));
            walkingFrameLeft = new AnimationFrame(game.Content.Load<Texture2D>("ForwardLeftFoot"));
            stillFrameTwo = new AnimationFrame(game.Content.Load<Texture2D>("ForwardStill"));
            walkingFrameRight = new AnimationFrame(game.Content.Load<Texture2D>("ForwardRightFoot"));
            stillFrameOne.NextFrame = walkingFrameLeft;
            walkingFrameLeft.NextFrame = stillFrameTwo;
            stillFrameTwo.NextFrame = walkingFrameRight;
            walkingFrameRight.NextFrame = stillFrameOne;

            this.StartFrame = walkingFrameLeft;
            this.CurrentFrame = StartFrame;
        }
    }
}

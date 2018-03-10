using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword.PlayerFolder.Animations
{
    public class WalkUpAnimation : Animation
    {
        AnimationFrame stillFrameOne;
        AnimationFrame walkingFrameLeft;
        AnimationFrame stillFrameTwo;
        AnimationFrame walkingFrameRight;

        public WalkUpAnimation(Game game)
        {
            stillFrameOne = new AnimationFrame(game.Content.Load<Texture2D>("BackwardsStill"));
            walkingFrameLeft = new AnimationFrame(game.Content.Load<Texture2D>("BackwardsLeftFoot"));
            stillFrameTwo = new AnimationFrame(game.Content.Load<Texture2D>("BackwardsStill"));
            walkingFrameRight = new AnimationFrame(game.Content.Load<Texture2D>("BackwardsRightFoot"));
            stillFrameOne.NextFrame = walkingFrameLeft;
            walkingFrameLeft.NextFrame = stillFrameTwo;
            stillFrameTwo.NextFrame = walkingFrameRight;
            walkingFrameRight.NextFrame = stillFrameOne;

            this.StartFrame = walkingFrameLeft;
            this.CurrentFrame = StartFrame;
        }
    }
}

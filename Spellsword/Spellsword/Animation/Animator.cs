using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spellsword.PlayerFolder.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Animator
    {
        private Game thisGame;
        private Sprite spriteToAnimate;
        public Animation CurrentAnimation { get; private set; }

        public Animator(Game thisGame, Sprite spriteToAnimate)
        {
            this.thisGame = thisGame;
            this.spriteToAnimate = spriteToAnimate;
            WalkingPlayer.PlayerChangedState += ChangeAnimation;
        }

        private void ChangeAnimation(WalkingState currentWalkingState, WalkingState previousWalkingState)
        {
            switch (currentWalkingState)
            {
                case WalkingState.Left:
                    CurrentAnimation = new WalkLeftAnimation(thisGame);
                    break;
                case WalkingState.Right:
                    CurrentAnimation = new WalkRightAnimation(thisGame);
                    break;
                case WalkingState.Up:
                    CurrentAnimation = new WalkUpAnimation(thisGame);
                    break;
                case WalkingState.Down:
                    CurrentAnimation = new WalkDownAnimation(thisGame);
                    break;
                case WalkingState.Still:
                    CurrentAnimation = null;
                    LoadAppropriateStillTexture(previousWalkingState);
                    break;
            }
        }

        private void LoadAppropriateStillTexture(WalkingState previousWalkingState)
        {
            switch(previousWalkingState)
            {
                case WalkingState.Left:
                    this.spriteToAnimate.CurrentSprite = thisGame.Content.Load<Texture2D>("LeftStill");
                    break;
                case WalkingState.Right:
                    this.spriteToAnimate.CurrentSprite = thisGame.Content.Load<Texture2D>("RightStill");
                    break;
                case WalkingState.Up:
                    this.spriteToAnimate.CurrentSprite = thisGame.Content.Load<Texture2D>("BackwardsStill");
                    break;
                case WalkingState.Down:
                    this.spriteToAnimate.CurrentSprite = thisGame.Content.Load<Texture2D>("ForwardStill");
                    break;
                default:
                    this.spriteToAnimate.CurrentSprite = thisGame.Content.Load<Texture2D>("ForwardStill");
                    break;

            }
        }
    }
}

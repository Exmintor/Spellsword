using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spellsword.PlayerFolder.Animations;

namespace Spellsword
{
    public enum WalkingState { Still, Left, Right, Up, Down }
    public class WalkingPlayer : WorldEntity
    {
        public static event Action<WalkingState, WalkingState> PlayerChangedState;

        private Animator animator;
        private PlayerController controller;
        public Point CurrentTileLocation { get; private set; }

        private WalkingState previousWalkingState;
        private WalkingState currentWalkingState;
        public WalkingState CurrentWalkingState
        {
            get
            {
                return currentWalkingState;
            }
            set
            {
                if(currentWalkingState != value)
                {
                    previousWalkingState = currentWalkingState;
                    currentWalkingState = value;
                    PlayerChangedState.Invoke(currentWalkingState, previousWalkingState);
                }
            }
        }

        private bool isWalking;
        private Stack<Vector2> MovementQueue;
        private float walkingTimeElapsed = 0;

        public WalkingPlayer(SpellswordGame game, World gameWorld)
        {
            this.game = game;
            this.gameWorld = gameWorld;
            this.thisEntity = new Player();

            animator = new Animator(game, this);
            controller = new PlayerController(game);
            this.CurrentTileLocation = new Point(8, 21);
            this.Location = gameWorld.GetTileLocation(CurrentTileLocation);

            CurrentSprite = game.Content.Load<Texture2D>("ForwardStill");
            CurrentWalkingState = WalkingState.Still;

            MovementQueue = new Stack<Vector2>();
        }

        public virtual void Update(GameTime gameTime)
        {
            controller.Update(this);
            if(isWalking)
            {
                if(MovementQueue.Count != 0)
                {
                    walkingTimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if(walkingTimeElapsed >= Parameters.playerMovementSpeed)
                    {
                        walkingTimeElapsed = 0;
                        this.Location += MovementQueue.Pop();
                        if(this.animator.CurrentAnimation != null)
                        {
                            this.animator.CurrentAnimation.Update(this);
                        }
                    }
                }
                else
                {
                    isWalking = false;
                }
            }
        }

        public void MoveUp()
        {
            if (!isWalking)
            {
                isWalking = true;
                this.CurrentWalkingState = WalkingState.Up;
                Point desiredTileLocation = new Point(CurrentTileLocation.X, CurrentTileLocation.Y - 1);
                if (gameWorld.IsOnMap(desiredTileLocation) && !gameWorld.IsOccupied(desiredTileLocation))
                {
                    QueueMovement(new Vector2(0, -1 * Parameters.pixelsMovedPerFrame));
                    QueueMovement(new Vector2(0, -1 * Parameters.pixelsMovedPerFrame));
                    //this.CurrentTileLocation.Y -= 1;
                    this.CurrentTileLocation = new Point(CurrentTileLocation.X, CurrentTileLocation.Y - 1);
                }
                else
                {
                    QueueMovement(new Vector2(0, 0));
                    QueueMovement(new Vector2(0, 0));
                }
            }
        }

        public void MoveDown()
        {
            if (!isWalking)
            {
                isWalking = true;
                this.CurrentWalkingState = WalkingState.Down;
                Point desiredTileLocation = new Point(CurrentTileLocation.X, CurrentTileLocation.Y + 1);
                if (gameWorld.IsOnMap(desiredTileLocation) && !gameWorld.IsOccupied(desiredTileLocation))
                {
                    QueueMovement(new Vector2(0, 1 * Parameters.pixelsMovedPerFrame));
                    QueueMovement(new Vector2(0, 1 * Parameters.pixelsMovedPerFrame));
                    //this.CurrentTileLocation.Y += 1;
                    this.CurrentTileLocation = new Point(CurrentTileLocation.X, CurrentTileLocation.Y + 1);
                }
                else
                {
                    QueueMovement(new Vector2(0, 0));
                    QueueMovement(new Vector2(0, 0));
                }
            }
        }

        public void MoveLeft()
        {
            if (!isWalking)
            {
                isWalking = true;
                this.CurrentWalkingState = WalkingState.Left;
                Point desiredTileLocation = new Point(CurrentTileLocation.X - 1, CurrentTileLocation.Y);
                if (gameWorld.IsOnMap(desiredTileLocation) && !gameWorld.IsOccupied(desiredTileLocation))
                {
                    QueueMovement(new Vector2(-1 * Parameters.pixelsMovedPerFrame, 0));
                    QueueMovement(new Vector2(-1 * Parameters.pixelsMovedPerFrame, 0));
                    //this.CurrentTileLocation.X -= 1;
                    this.CurrentTileLocation = new Point(CurrentTileLocation.X - 1, CurrentTileLocation.Y);
                }
                else
                {
                    QueueMovement(new Vector2(0, 0));
                    QueueMovement(new Vector2(0, 0));
                }
            }
        }

        public void MoveRight()
        {
            if (!isWalking)
            {
                isWalking = true;
                this.CurrentWalkingState = WalkingState.Right;
                Point desiredTileLocation = new Point(CurrentTileLocation.X + 1, CurrentTileLocation.Y);
                if (gameWorld.IsOnMap(desiredTileLocation) && !gameWorld.IsOccupied(desiredTileLocation))
                {
                    QueueMovement(new Vector2(1 * Parameters.pixelsMovedPerFrame, 0));
                    QueueMovement(new Vector2(1 * Parameters.pixelsMovedPerFrame, 0));
                    //this.CurrentTileLocation.X += 1;
                    this.CurrentTileLocation = new Point(CurrentTileLocation.X + 1, CurrentTileLocation.Y);
                }
                else
                {
                    QueueMovement(new Vector2(0, 0));
                    QueueMovement(new Vector2(0, 0));
                }
            }
        }

        public void Stop()
        {
            if(!isWalking)
            {
                CurrentWalkingState = WalkingState.Still;
            }
        }

        public void Interact()
        {
            if(!isWalking)
            {
                Point locationToInteractWith = this.CurrentTileLocation;
                switch (previousWalkingState)
                {
                    case WalkingState.Left:
                        locationToInteractWith.X -= 1;
                        break;
                    case WalkingState.Right:
                        locationToInteractWith.X += 1;
                        break;
                    case WalkingState.Up:
                        locationToInteractWith.Y -= 1;
                        break;
                    case WalkingState.Down:
                        locationToInteractWith.Y += 1;
                        break;
                }
                InteractWithEntityOnSpace(locationToInteractWith);
            }
        }

        private void InteractWithEntityOnSpace(Point relativeLocation)
        {
            if(gameWorld.IsOnMap(relativeLocation) && gameWorld.IsOccupied(relativeLocation))
            {
                WorldEntity thingToInteractWith = gameWorld.GetEntityAtLocation(relativeLocation);
                if (thingToInteractWith is IInteractable && thisEntity is Character)
                {
                    ((IInteractable)thingToInteractWith).Interact((Character)this.thisEntity);
                }
            }
        }

        private void QueueMovement(Vector2 movement)
        {
            MovementQueue.Push(movement);
        }

        public Entity GetEntity()
        {
            return thisEntity;
        }
    }
}

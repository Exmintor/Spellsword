using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class WorldEnemy: WorldEntity, IInteractable
    {
        private bool shouldDraw;
        private Point pointLocation;
        public WorldEnemy(SpellswordGame game, World gameWorld, Point pointLocation, Character enemy)
        {
            shouldDraw = true;
            this.game = game;
            this.gameWorld = gameWorld;
            thisEntity = enemy;
            if(thisEntity is Character)
            {
                ((Character)thisEntity).Died += OnEntityDied;
            }

            //Temp test
            this.CurrentSprite = game.Content.Load<Texture2D>(enemy.WorldImage);
            this.pointLocation = pointLocation;
            this.Location = gameWorld.GetTileLocation(pointLocation);
            gameWorld.RegisterEntity(this, pointLocation);
            if(this.thisEntity is Dragon)
            {
                this.Location -= new Vector2(32, 32);
                gameWorld.RegisterEntity(this, new Point(pointLocation.X - 1, pointLocation.Y));
                gameWorld.RegisterEntity(this, new Point(pointLocation.X + 1, pointLocation.Y));
                gameWorld.RegisterEntity(this, new Point(pointLocation.X, pointLocation.Y - 1));
                gameWorld.RegisterEntity(this, new Point(pointLocation.X, pointLocation.Y + 1));
                gameWorld.RegisterEntity(this, new Point(pointLocation.X - 1, pointLocation.Y - 1));
                gameWorld.RegisterEntity(this, new Point(pointLocation.X - 1, pointLocation.Y + 1));
                gameWorld.RegisterEntity(this, new Point(pointLocation.X + 1, pointLocation.Y - 1));
                gameWorld.RegisterEntity(this, new Point(pointLocation.X + 1, pointLocation.Y + 1));
            }
        }

        public void Interact(Character agentInteracting)
        {
            if(thisEntity is Character)
            {
                game.InitiateBattle(agentInteracting, (Character)this.thisEntity);
            }
        }

        private void OnEntityDied(Entity entityThatDied)
        {
            gameWorld.UnregisterEntity(pointLocation);
            if (entityThatDied is Dragon)
            {
                gameWorld.UnregisterEntity(new Point(pointLocation.X - 1, pointLocation.Y));
                gameWorld.UnregisterEntity(new Point(pointLocation.X + 1, pointLocation.Y));
                gameWorld.UnregisterEntity(new Point(pointLocation.X, pointLocation.Y - 1));
                gameWorld.UnregisterEntity(new Point(pointLocation.X, pointLocation.Y + 1));
                gameWorld.UnregisterEntity(new Point(pointLocation.X - 1, pointLocation.Y - 1));
                gameWorld.UnregisterEntity(new Point(pointLocation.X - 1, pointLocation.Y + 1));
                gameWorld.UnregisterEntity(new Point(pointLocation.X + 1, pointLocation.Y - 1));
                gameWorld.UnregisterEntity(new Point(pointLocation.X + 1, pointLocation.Y + 1));
            }
            shouldDraw = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(shouldDraw)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}

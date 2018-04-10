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
        public WorldEnemy(SpellswordGame game, World gameWorld, Point pointLocation)
        {
            shouldDraw = true;
            this.game = game;
            this.gameWorld = gameWorld;
            thisEntity = new Enemy();
            if(thisEntity is Character)
            {
                ((Character)thisEntity).Died += OnEntityDied;
            }

            //Temp test
            this.CurrentSprite = game.Content.Load<Texture2D>("BackwardsStill");
            this.pointLocation = pointLocation;
            this.Location = gameWorld.GetTileLocation(pointLocation);
            gameWorld.RegisterEntity(this, pointLocation);
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

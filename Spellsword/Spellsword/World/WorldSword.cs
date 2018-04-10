using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class WorldSword : WorldEntity, IInteractable
    {
        private bool shouldDraw;
        private Point pointLocation;

        public WorldSword(SpellswordGame game, World gameWorld, Point startingLocation)
        {
            shouldDraw = true;
            this.game = game;
            this.gameWorld = gameWorld;

            this.thisEntity = new BasicSword();

            this.CurrentSprite = game.Content.Load<Texture2D>("BasicSword");
            this.pointLocation = startingLocation;
            this.Location = gameWorld.GetTileLocation(pointLocation);
            gameWorld.RegisterEntity(this, pointLocation);
        }

        public void Interact(Character agentInteracting)
        {
            if(agentInteracting is Player && thisEntity is IWeapon)
            {
                ((Player)agentInteracting).GiveNewWeapon((IWeapon)thisEntity);
                this.shouldDraw = false;
                gameWorld.UnregisterEntity(pointLocation);
            }
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

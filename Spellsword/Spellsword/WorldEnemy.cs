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
        public WorldEnemy(SpellswordGame game, World gameWorld)
        {
            this.game = game;
            this.gameWorld = gameWorld;
            thisEntity = new Enemy();

            //Temp test
            this.CurrentSprite = game.Content.Load<Texture2D>("BackwardsStill");
            this.Location = gameWorld.GetTileLocation(new Point(1, 0));
            gameWorld.RegisterEntity(this, new Point(1, 0));
        }

        public void Interact(Entity agentInteracting)
        {
            game.InitiateBattle(agentInteracting, this.thisEntity);
        }
    }
}

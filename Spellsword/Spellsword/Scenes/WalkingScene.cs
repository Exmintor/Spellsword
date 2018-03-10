using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword.Scenes
{
    public class WalkingScene
    {
        private SpellswordGame game;
        private World thisWorld;
        private WalkingPlayer player;
        //Temp test
        private WorldEnemy enemy;
        public WalkingScene(SpellswordGame game, World thisWorld, WalkingPlayer player)
        {
            this.game = game;
            this.thisWorld = thisWorld;
            this.player = player;
            //Temp test
            this.enemy = new WorldEnemy(game, thisWorld);
        }

        public virtual void Update(GameTime gameTime)
        {
            Vector2 oldPlayerLocation = player.Location;
            player.Update(gameTime);
            if (player.Location != oldPlayerLocation)
            {
                MoveEntireWorld(oldPlayerLocation - player.Location);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            thisWorld.Draw(spriteBatch);
            player.Draw(spriteBatch);
            //Temp test
            enemy.Draw(spriteBatch);
        }

        private void MoveEntireWorld(Vector2 amountToMove)
        {
            thisWorld.StartingLocation += amountToMove;
            player.Location += amountToMove;
            //Temp test
            enemy.Location += amountToMove;
        }
    }
}

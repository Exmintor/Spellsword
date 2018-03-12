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
        private List<WorldEnemy> enemies;
        public WalkingScene(SpellswordGame game, World thisWorld, WalkingPlayer player)
        {
            this.game = game;
            this.thisWorld = thisWorld;
            this.player = player;
            //Temp test
            enemies = new List<WorldEnemy>();
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(1,0)));
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(8, 1)));
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(2, 8)));
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(9, 8)));
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
            foreach(WorldEnemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        private void MoveEntireWorld(Vector2 amountToMove)
        {
            thisWorld.StartingLocation += amountToMove;
            player.Location += amountToMove;
            //Temp test
            foreach(WorldEnemy enemy in enemies)
            {
                enemy.Location += amountToMove;
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword.Scenes
{
    public class WalkingScene
    {
        private InputHandler inputHandler;

        private SpellswordGame game;
        private World thisWorld;
        private WalkingPlayer player;
        //Temp test
        private List<WorldEnemy> enemies;
        private List<WorldSword> swords;
        public WalkingScene(SpellswordGame game, World thisWorld, WalkingPlayer player)
        {
            inputHandler = game.Services.GetService<InputHandler>();
            if (inputHandler == null)
            {
                inputHandler = new InputHandler(game);
                game.Components.Add(inputHandler);
            }

            this.game = game;
            this.thisWorld = thisWorld;
            this.player = player;
            //Temp test
            enemies = new List<WorldEnemy>();
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(1,0)));
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(8, 1)));
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(2, 8)));
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(9, 8)));
            // More Temp Test
            swords = new List<WorldSword>();
            this.swords.Add(new WorldSword(game, thisWorld, new Point(0, 0)));
            this.swords.Add(new WorldSword(game, thisWorld, new Point(5, 3)));
            this.swords.Add(new WorldSword(game, thisWorld, new Point(10, 10)));
        }

        public virtual void Update(GameTime gameTime)
        {
            if(inputHandler.WasButtonPressed(Keys.E))
            {
                game.OpenEquipmentMenu((Player)player.GetEntity());
            }
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
            foreach(WorldSword sword in swords)
            {
                sword.Draw(spriteBatch);
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
            foreach(WorldSword sword in swords)
            {
                sword.Location += amountToMove;
            }
        }
    }
}

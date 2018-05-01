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
    public class WalkingScene : Scene
    {
        private InputHandler inputHandler;

        private SpellswordGame game;
        private World thisWorld;
        private WalkingPlayer player;
        //Temp test
        private List<WorldEnemy> enemies;
        private List<WorldSword> swords;
        private List<EmptyTile> emptyTiles;
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

            string[] mapFile =
            {
                "11111110001111111",
                "11111110001111111",
                "11111110001111111",
                "11110000000001111",
                "11110000000001111",
                "11110000000001111",
                "00010000000001000",
                "00000000000000000",
                "00010000000001000",
                "11110000000001111",
                "11110000000001111",
                "11110000000001111",
                "00010000000001000",
                "00000000000000000",
                "00010000000001000",
                "11110000000001111",
                "11110000000001111",
                "11110000000001111",
                "11110000000001111",
                "11111111011111111",
                "11111110001111111",
                "11111110001111111",
                "11111110001111111"
            };

            emptyTiles = new List<EmptyTile>();
            CreateEmptyTiles(game, mapFile);

            //Temp test
            Enemy ghost1 = new Enemy("BackwardsStill", "Ghost");
            Enemy ghost2 = new Enemy("BackwardsStill", "Ghost");
            Enemy ghost3 = new Enemy("BackwardsStill", "Ghost");
            Enemy ghost4 = new Enemy("BackwardsStill", "Ghost");
            Enemy ghost5 = new Enemy("BackwardsStill", "Ghost");
            Enemy ghost6 = new Enemy("BackwardsStill", "Ghost");
            enemies = new List<WorldEnemy>();
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(3, 7), ghost1)); // Welp
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(3, 13), ghost2)); // Zombie
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(13, 7), ghost3)); // Wraith
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(13, 13), ghost4)); // Ghost
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(8, 19), ghost5)); // Flower
            this.enemies.Add(new WorldEnemy(game, thisWorld, new Point(8, 1), ghost6)); // Dragon Boss

            // More Temp Test
            swords = new List<WorldSword>();
            this.swords.Add(new WorldSword(game, thisWorld, new Point(1, 7))); // Ice Shield
            this.swords.Add(new WorldSword(game, thisWorld, new Point(1, 13))); // Ice Blade
            this.swords.Add(new WorldSword(game, thisWorld, new Point(15, 7))); // Lightning Blade
            this.swords.Add(new WorldSword(game, thisWorld, new Point(15, 13))); // Spell/Power Focus

            InitializePlayerToMiddle();
        }

        public virtual void Update(GameTime gameTime)
        {
            if (inputHandler.WasButtonPressed(Keys.P))
            {
                game.PauseGame();
            }
            if (inputHandler.WasButtonPressed(Keys.E))
            {
                game.OpenMenu((Player)player.GetEntity());
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
            foreach(EmptyTile tile in emptyTiles)
            {
                tile.Draw(spriteBatch);
            }
        }

        private void InitializePlayerToMiddle()
        {
            Point playerTileLocation = player.CurrentTileLocation;
            Vector2 screenMiddle = thisWorld.GetStartingMiddle();
            Vector2 playerLocation = thisWorld.GetTileLocation(playerTileLocation);
            Vector2 offset = screenMiddle - playerLocation;
            MoveEntireWorld(offset);
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
            foreach(EmptyTile tile in emptyTiles)
            {
                tile.Location += amountToMove;
            }
        }

        private void CreateEmptyTiles(SpellswordGame game, string[] mapFile)
        {
            for (int i = 0; i < thisWorld.ySize; i++)
            {
                for (int j = 0; j < thisWorld.xSize; j++)
                {
                    if (mapFile[i][j] == '1')
                    {
                        Point newPoint = new Point(j, i);
                        EmptyTile tile = new EmptyTile(game, thisWorld, newPoint);
                        emptyTiles.Add(tile);
                        thisWorld.RegisterEntity(tile, newPoint);
                    }
                }
            }
        }
    }
}

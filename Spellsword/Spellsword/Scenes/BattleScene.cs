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
    public class BattleScene
    {
        private SpellswordGame game;
        private BattleEntity player;
        private BattleEntity enemy;

        private Queue<BattleAction> battleQueue;
        private bool turnInProgress = false;

        public BattleScene(SpellswordGame game, Entity player, Entity enemy)
        {
            this.game = game;
            ChangeCombatants(player, enemy);
        }

        public void ChangeCombatants(Entity player, Entity enemy)
        {
            if (player is Player)
            {
                this.player = new BattlePlayer(this, (Player)player);
            }
            else
            {
                this.player = new BattleEnemy(this, (Enemy)player);
            }

            if (enemy is Enemy)
            {
                this.enemy = new BattleEnemy(this, (Enemy)enemy);
            }
            else
            {
                this.enemy = new BattlePlayer(this, (Player)enemy);
            }
        }

        public void Update(GameTime gameTime)
        {
            if(turnInProgress)
            {
                ResolveTurn();
            }
            else
            {
                TakeTurn();
            }
            //Temp test
            if(Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                game.SwitchToWorld();
            }
        }

        private void ResolveTurn()
        {
            if (battleQueue.Count != 0)
            {
                battleQueue.Dequeue().Resolve();
            }
            else
            {
                turnInProgress = false;
            }
        }

        private void TakeTurn()
        {
            battleQueue.Enqueue(player.TakeTurn());
            if(player is BattlePlayer)
            {
                battleQueue.Enqueue(((BattlePlayer)player).TakeSecondTurn());
            }
            battleQueue.Enqueue(enemy.TakeTurn());
            if (enemy is BattlePlayer)
            {
                battleQueue.Enqueue(((BattlePlayer)enemy).TakeSecondTurn());
            }
            turnInProgress = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Temp test
            spriteBatch.Draw(game.Content.Load<Texture2D>("BaseTile"), new Vector2(0, 0), Color.Red);
        }

        public BattleEntity GetOpponent(BattleEntity entityAsking)
        {
            if(entityAsking == player)
            {
                return enemy;
            }
            else
            {
                return player;
            }
        }
    }
}

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
    public enum BattleSceneState { Idle, Waiting, Menu, InProgress }
    public class BattleScene
    {
        private SpellswordGame game;
        private BattleEntity player;
        private BattleEntity enemy;

        private BattleMenu currentMenu;
        private BattleSceneState currentState;

        private Queue<BattleAction> battleQueue;

        public BattleScene(SpellswordGame game, Entity player, Entity enemy)
        {
            this.game = game;
            ChangeCombatants(game, player, enemy);

            currentMenu = null;
            currentState = BattleSceneState.Idle;

            battleQueue = new Queue<BattleAction>();
        }

        public void ChangeCombatants(Game game, Entity player, Entity enemy)
        {
            if (player is Player)
            {
                this.player = new BattlePlayer(game, this, (Player)player);
            }
            else
            {
                this.player = new BattleEnemy(game, this, (Enemy)player);
            }

            if (enemy is Enemy)
            {
                this.enemy = new BattleEnemy(game, this, (Enemy)enemy);
            }
            else
            {
                this.enemy = new BattlePlayer(game, this, (Player)enemy);
            }
            if (this.player is BattlePlayer)
            {
                ((BattlePlayer)this.player).FinishedTurn += OnPlayerFinishedTurn;
            }

            if(this.player.ThisEntity != null)
            {
                this.player.ThisEntity.Died += EndCombat;
            }
            if(this.enemy.ThisEntity != null)
            {
                this.enemy.ThisEntity.Died += EndCombat;
            }
        }

        public void Update(GameTime gameTime)
        {
            switch (currentState)
            {
                case BattleSceneState.Idle:
                    TakeTurn();
                    break;
                case BattleSceneState.Waiting:
                    player.Update();
                    enemy.Update();
                    if(currentMenu != null)
                    {
                        currentMenu.Update();
                    }
                    break;
                case BattleSceneState.InProgress:
                    ResolveTurn();
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            Vector2 playerHealthLocation = new Vector2(20, 10);
            spriteBatch.DrawString(game.Content.Load<SpriteFont>("Arial"), "Health: " + player.ThisEntity.Health, playerHealthLocation, Color.White);
            enemy.Draw(spriteBatch);
            Vector2 enemyHealthLocation = new Vector2(180, 10);
            spriteBatch.DrawString(game.Content.Load<SpriteFont>("Arial"), "Health: " + enemy.ThisEntity.Health, enemyHealthLocation, Color.White);
            if (currentState == BattleSceneState.Waiting && currentMenu != null)
            {
                currentMenu.Draw(spriteBatch);
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
                currentState = BattleSceneState.Idle;
            }
        }

        private void TakeTurn()
        {
            player.TakeTurn();
            enemy.TakeTurn();
            currentState = BattleSceneState.Waiting;
        }

        public BattleEntity GetOpponent(BattleEntity entityAsking)
        {
            if(entityAsking == player)
            {
                return enemy;
            }
            else if(entityAsking == enemy)
            {
                return player;
            }
            return null;
        }

        public void QueueAction(BattleAction action)
        {
            battleQueue.Enqueue(action);
        }

        private void OnPlayerFinishedTurn()
        {
            currentState = BattleSceneState.InProgress;
        }

        public void SetBattleMenu(BattleMenu menu)
        {
            this.currentMenu = menu;
        }

        private void EndCombat()
        {
            game.SwitchToWorld();
        }
    }
}

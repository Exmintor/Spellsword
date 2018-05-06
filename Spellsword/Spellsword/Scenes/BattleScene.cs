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
    public enum BattleSceneState { Idle, Waiting, ResolveStatusEffectsBefore, InProgress, ResolveStatusEffectsAfter }
    public class BattleScene : MenuScene
    {
        private SpellswordGame game;
        private BattleEntity player;
        private BattleEntity enemy;
        private bool bothAlive;

        private BattleSceneState currentState;

        private Stack<BattleAction> battleQueue;

        public BattleScene(SpellswordGame game, Character player, Character enemy) : base(game, null)
        {
            this.game = game;
            ChangeCombatants(game, player, enemy);
            bothAlive = true;

            currentMenu = null;
            currentState = BattleSceneState.Idle;

            battleQueue = new Stack<BattleAction>();
        }

        public void ChangeCombatants(SpellswordGame game, Character player, Character enemy)
        {
            if (player is Player)
            {
                this.player = new BattlePlayer(game, this, (Player)player);
            }

            this.enemy = new BattleEnemy(game, this, enemy);

            if (this.player is BattlePlayer)
            {
                ((BattlePlayer)this.player).FinishedTurn += OnPlayerFinishedTurn;
            }

            if(this.player.ThisEntity != null)
            {
                this.player.ThisEntity.Died += HandleDeath;
            }
            if(this.enemy.ThisEntity != null)
            {
                this.enemy.ThisEntity.Died += HandleDeath;
            }
        }

        public override void Update(GameTime gameTime)
        {
            switch (currentState)
            {
                case BattleSceneState.Idle:
                    TakeTurn();
                    break;
                case BattleSceneState.ResolveStatusEffectsBefore:
                    enemy.ThisEntity.ResolveStatusEffectsBefore();
                    player.ThisEntity.ResolveStatusEffectsBefore();
                    CheckForDeath();
                    this.currentState = BattleSceneState.Waiting;
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
                    CheckForDeath();
                    break;
                case BattleSceneState.ResolveStatusEffectsAfter:
                    enemy.ThisEntity.ResolveStatusEffectsAfter();
                    player.ThisEntity.ResolveStatusEffectsAfter();
                    CheckForDeath();
                    this.currentState = BattleSceneState.Idle;
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            Vector2 playerHealthLocation = player.Location + Parameters.battlePlayerHealthOffset;
            spriteBatch.DrawString(game.Content.Load<SpriteFont>("Arial"), "Health: " + player.ThisEntity.Health, playerHealthLocation, Color.White);
            Vector2 playerStatusLocation = player.Location + Parameters.battlePlayerStatusOffset;
            foreach(IStatusEffect effect in player.ThisEntity.StatusEffects)
            {
                spriteBatch.DrawString(game.Content.Load<SpriteFont>("Arial"), effect.Name, playerStatusLocation, Color.White);
                playerStatusLocation += Parameters.statusEffectOffset;
            }
            Vector2 enemyStatusLocation = enemy.Location + Parameters.battleEnemyStatusOffset;
            foreach (IStatusEffect effect in enemy.ThisEntity.StatusEffects)
            {
                spriteBatch.DrawString(game.Content.Load<SpriteFont>("Arial"), effect.Name, enemyStatusLocation, Color.White);
                enemyStatusLocation += Parameters.statusEffectOffset;
            }
            enemy.Draw(spriteBatch);
            Vector2 enemyHealthLocation = enemy.Location + Parameters.battleEnemyHealthOffset;
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
                battleQueue.Pop().Resolve();
                //battleQueue.Dequeue().Resolve();
            }
            else
            {
                currentState = BattleSceneState.ResolveStatusEffectsAfter;
            }
        }

        private void TakeTurn()
        {
            player.TakeTurn();
            enemy.TakeTurn();
            currentState = BattleSceneState.ResolveStatusEffectsBefore;
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
            battleQueue.Push(action);
            //battleQueue.Enqueue(action);
        }

        private void OnPlayerFinishedTurn()
        {
            currentState = BattleSceneState.InProgress;
        }

        public void SetBattleMenu(BattleMenu menu)
        {
            this.currentMenu = menu;
        }

        private void HandleDeath(Entity entityThatDied)
        {
            if (entityThatDied is Enemy)
            {
                ((Player)player.ThisEntity).GainRewards((((Enemy)entityThatDied).Reward));
            }
            bothAlive = false;
        }

        public void UnsubscribeDeathHandlers()
        {
            this.player.ThisEntity.Died -= HandleDeath;
            this.enemy.ThisEntity.Died -= HandleDeath;
        }

        private void CheckForDeath()
        {
            if(bothAlive == false)
            {
                player.ThisEntity.RemoveAllStatusEffects();
                EndCombat();
            }
        }
        public void EndCombat()
        {
            if(player.ThisEntity.IsAlive)
            {
                player.ThisEntity.HealToMax();
                game.SwitchToWorld();
            }
            else
            {
                game.ResetGame();
            }
        }
    }
}

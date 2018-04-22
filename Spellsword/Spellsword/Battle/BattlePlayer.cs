using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spellsword.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public enum BattlePlayerState { Waiting, FirstAction, SecondAction }
    public class BattlePlayer : BattleEntity
    {
        private SpellswordGame game;
        public event Action FinishedTurn;

        private BattlePlayerState currentState;
        public BattlePlayerState CurrentState
        {
            get
            {
                return currentState;
            }
            private set
            {
                if(value == BattlePlayerState.FirstAction)
                {
                    menu = new BattleMenu(game, ThisEntity, ((Player)ThisEntity).FirstWeapon);
                    menu.ActionChosen += OnActionChosen;
                }
                else if(value == BattlePlayerState.SecondAction)
                {
                    menu.ActionChosen -= OnActionChosen;
                    menu = new BattleMenu(game, ThisEntity, ((Player)ThisEntity).SecondWeapon);
                    menu.ActionChosen += OnActionChosen;
                }
                else
                {
                    if(menu != null)
                    {
                        menu.ActionChosen -= OnActionChosen;
                    }
                    menu = null;
                }
                currentScene.SetBattleMenu(menu);
                currentState = value;
            }
        }
        private bool hasFinishedAction = false;
        private BattleMenu menu;

        public BattlePlayer(SpellswordGame game, BattleScene currentScene, Player player)
        {
            this.CurrentSprite = game.Content.Load<Texture2D>("SpellSword");
            this.Location = Parameters.battlePlayerLocation;

            this.game = game;

            this.currentScene = currentScene;
            this.ThisEntity = player;

            this.CurrentState = BattlePlayerState.Waiting;

        }

        public override void Update()
        {
            switch(CurrentState)
            {
                case BattlePlayerState.Waiting:
                    if(this.shouldAct)
                    {
                        CurrentState = BattlePlayerState.FirstAction;
                    }
                    break;
                case BattlePlayerState.FirstAction:
                    if(hasFinishedAction)
                    {
                        CurrentState = BattlePlayerState.SecondAction;
                        hasFinishedAction = false;
                    }
                    break;
                case BattlePlayerState.SecondAction:
                    if(hasFinishedAction)
                    {
                        CurrentState = BattlePlayerState.Waiting;
                        hasFinishedAction = false;
                        if(FinishedTurn != null)
                        {
                            FinishedTurn.Invoke();
                        }
                        shouldAct = false;
                    }
                    break;
            }

        }

        private void OnActionChosen(IAction actionChosen)
        {
            BattleEntity target;
            if(actionChosen is ISelfTargetAction)
            {
                target = this;
            }
            else
            {
                target = currentScene.GetOpponent(this);
            }
            BattleAction action = new BattleAction(this.ThisEntity, target.ThisEntity, actionChosen);
            currentScene.QueueAction(action);
            hasFinishedAction = true;
        }

        public override void TakeTurn()
        {
            shouldAct = true;
        }
    }
}

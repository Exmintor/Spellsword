using Spellsword.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class BattleEntity : Sprite
    {
        protected BattleScene currentScene;
        public Entity ThisEntity { get; protected set; }

        protected bool shouldAct;

        public virtual void Update()
        {
            if(shouldAct)
            {
                BattleAction actionToAdd = TakeAction();
                currentScene.QueueAction(actionToAdd);
                shouldAct = false;
            }
        }

        public virtual void TakeTurn()
        {
            shouldAct = true;
        }

        protected virtual BattleAction TakeAction()
        {
            IAction action = ThisEntity.ChooseAction();
            BattleAction battleAction = TakeAction(action);
            return battleAction;
        }

        protected virtual BattleAction TakeAction(IAction action)
        {
            BattleEntity battleTarget = currentScene.GetOpponent(this);
            Entity target = battleTarget.ThisEntity;
            BattleAction battleAction = new BattleAction(target, action);
            return battleAction;
        }
    }
}

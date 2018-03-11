using Spellsword.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class BattleEntity
    {
        protected BattleScene currentScene;
        public Entity ThisEntity { get; protected set; }

        public virtual BattleAction TakeTurn()
        {
            IAction action = ThisEntity.ChooseAction();
            BattleAction battleAction = TakeTurn(action);
            return battleAction;
        }

        protected virtual BattleAction TakeTurn(IAction action)
        {
            BattleEntity battleTarget = currentScene.GetOpponent(this);
            Entity target = battleTarget.ThisEntity;
            BattleAction battleAction = new BattleAction(target, action);
            return battleAction;
        }
    }
}

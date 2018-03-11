using Spellsword.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BattlePlayer : BattleEntity
    {
        public BattlePlayer(BattleScene currentScene, Player player)
        {
            this.currentScene = currentScene;
            this.ThisEntity = player;
        }

        public override void Update()
        {
            if(shouldAct)
            {

            }

        } 
        public void TakeSecondAction()
        {
            IAction action = ((Player)ThisEntity).ChooseSecondAction();
            BattleAction battleAction = TakeAction(action);
            currentScene.QueueAction(battleAction);
        }

        public override void TakeTurn()
        {
            shouldAct = true;
        }
    }
}

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

        public BattleAction TakeSecondTurn()
        {
            IAction action = ((Player)ThisEntity).ChooseSecondAction();
            BattleAction battleAction = TakeTurn(action);
            return battleAction;
        }
    }
}

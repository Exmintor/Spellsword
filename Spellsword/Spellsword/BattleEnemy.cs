using Spellsword.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BattleEnemy : BattleEntity
    {
        public BattleEnemy(BattleScene currentScene, Enemy enemy)
        {
            this.currentScene = currentScene;
            this.ThisEntity = enemy;
        }
    }
}

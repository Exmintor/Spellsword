using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BackCommand : ISpellswordCommand
    {
        public string Name { get; private set; }

        private BattleMenu menu;

        public BackCommand(BattleMenu menu)
        {
            this.Name = "Back";
            this.menu = menu;
        }
        public void Execute()
        {
            menu.BackAction();
        }
    }
}

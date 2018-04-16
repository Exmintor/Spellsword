using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class AttackCommand : ISpellswordCommand
    {
        public string Name { get; private set; }

        private BattleMenu menu;

        public AttackCommand(BattleMenu menu)
        {
            this.Name = "Attack";
            this.menu = menu;
        }
        public void Execute()
        {
            menu.AttackAction();
        }
    }
}

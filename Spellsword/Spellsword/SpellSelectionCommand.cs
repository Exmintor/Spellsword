using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class SpellSelectionCommand : ISpellswordCommand
    {
        public string Name { get; private set; }

        private BattleMenu menu;

        public SpellSelectionCommand(BattleMenu menu)
        {
            this.Name = "Spells";
            this.menu = menu;
        }
        public void Execute()
        {
            menu.SpellSelection();
        }
    }
}

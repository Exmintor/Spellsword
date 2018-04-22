using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class NewSpellCommand : ISpellswordCommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private BattleMenu menu;
        private Attack spell;

        public NewSpellCommand(BattleMenu menu, Attack spell)
        {
            this.Name = spell.Name;
            this.Description = "Attack with " + spell.Name;
            this.menu = menu;
            this.spell = spell;
        }
        public void Execute()
        {
            menu.SpellAction(spell);
        }
    }
}

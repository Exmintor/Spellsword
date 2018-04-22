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

        private SpellswordGame game;
        private Menu newMenu;
        private Menu oldMenu;

        public BackCommand(SpellswordGame game, Menu newMenu, Menu oldMenu)
        {
            this.Name = "Back";
            this.game = game;
            this.newMenu = newMenu;
            this.oldMenu = oldMenu;
        }
        public void Execute()
        {
            newMenu.RemoveCommand(this);
            game.SwitchOutMenu(oldMenu);
        }
    }
}

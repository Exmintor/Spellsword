using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class SwitchMenuCommand : ISpellswordCommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private SpellswordGame game;
        private Menu oldMenu;
        private Menu newMenu;

        public SwitchMenuCommand(string Name, SpellswordGame game, Menu oldMenu, Menu newMenu)
        {
            this.Name = Name;
            this.Description = "Go to " + newMenu.ToString();
            this.game = game;
            this.oldMenu = oldMenu;
            this.newMenu = newMenu;
        }

        public void Execute()
        {
            game.SwitchOutMenu(newMenu);
            BackCommand command = new BackCommand(game, newMenu, oldMenu);
            newMenu.AddCommand(command);
        }
    }
}

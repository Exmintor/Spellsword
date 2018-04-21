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

        private MenuScene scene;
        private Menu oldMenu;
        private Menu newMenu;

        public SwitchMenuCommand(string Name, MenuScene scene, Menu oldMenu, Menu newMenu)
        {
            this.Name = Name;
            this.scene = scene;
            this.oldMenu = oldMenu;
            this.newMenu = newMenu;
        }

        public void Execute()
        {
            scene.SwitchOutMenu(oldMenu, newMenu);
            BackCommand command = new BackCommand(scene, newMenu, oldMenu);
            newMenu.AddCommand(command);
        }
    }
}

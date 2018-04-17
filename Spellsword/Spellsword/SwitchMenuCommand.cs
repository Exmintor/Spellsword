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

        public SwitchMenuCommand(MenuScene scene, Menu oldMenu, Menu newMenu)
        {
            this.scene = scene;
            this.oldMenu = oldMenu;
            this.newMenu = newMenu;
        }

        public void Execute()
        {
            scene.SwitchOutMenu(oldMenu, newMenu);
            SwitchMenuCommand command = new SwitchMenuCommand(scene, newMenu, oldMenu);
            command.Name = "Back";
            newMenu.AddCommand(command);
        }
    }
}

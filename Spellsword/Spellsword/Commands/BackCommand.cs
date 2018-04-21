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

        private MenuScene scene;
        private Menu newMenu;
        private Menu oldMenu;

        public BackCommand(MenuScene scene, Menu newMenu, Menu oldMenu)
        {
            this.Name = "Back";
            this.scene = scene;
            this.newMenu = newMenu;
            this.oldMenu = oldMenu;
        }
        public void Execute()
        {
            newMenu.RemoveCommand(this);
            scene.SwitchOutMenu(newMenu, oldMenu);
        }
    }
}

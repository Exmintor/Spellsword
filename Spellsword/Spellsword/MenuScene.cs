using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class MenuScene : Scene
    {
        protected Menu currentMenu;

        public void SwitchOutMenu(Menu oldMenu, Menu newMenu)
        {
            currentMenu = newMenu;
        }
    }
}

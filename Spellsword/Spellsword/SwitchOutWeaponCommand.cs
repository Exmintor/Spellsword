using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class SwitchOutWeaponCommand : ISpellswordCommand
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        private SwitchWeaponMenu menu;
        private IWeapon weapon;

        public SwitchOutWeaponCommand(SwitchWeaponMenu menu, IWeapon weapon)
        {
            this.menu = menu;
            this.weapon = weapon;

            this.Name = weapon.Name;
            this.Description = weapon.Description;
        }

        public void Execute()
        {
            menu.SwitchWeapon(weapon);
        }
    }
}

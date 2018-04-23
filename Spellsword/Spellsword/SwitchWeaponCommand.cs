using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class SwitchWeaponCommand : ISpellswordCommand
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        private SpellswordGame game;
        private EquipmentMenu oldMenu;
        private Player player;
        private int weaponIndex;

        public SwitchWeaponCommand(SpellswordGame game, EquipmentMenu oldMenu, Player player, IWeapon weapon, int weaponIndex)
        {
            this.game = game;
            this.oldMenu = oldMenu;
            this.player = player;
            this.weaponIndex = weaponIndex;

            this.Name = weapon.Name;
            this.Description = weapon.Description;
        }
        public void Execute()
        {
            SwitchWeaponMenu newMenu = new SwitchWeaponMenu(game, player, weaponIndex);
            game.SwitchOutMenu(newMenu);
            BackCommand command = new BackCommand(game, newMenu, oldMenu);
            newMenu.AddCommand(command);
        }
    }
}

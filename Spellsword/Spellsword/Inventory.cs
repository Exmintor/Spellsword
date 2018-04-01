using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Inventory
    {
        public List<IWeapon> Weapons { get; private set; }

        public Inventory()
        {
            Weapons = new List<IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            Weapons.Add(weapon);
        }

        public void RemoveWeapon(IWeapon weapon)
        {
            Weapons.Remove(weapon);
        }

        public IWeapon GetWeapon(int index)
        {
            return Weapons[index];
        }
    }
}

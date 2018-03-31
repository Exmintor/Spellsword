using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicSwordAttack : Attack
    {
        public BasicSwordAttack(IWeapon basicSword)
        {
            this.Damage = basicSword.Damage;
        }
    }
}

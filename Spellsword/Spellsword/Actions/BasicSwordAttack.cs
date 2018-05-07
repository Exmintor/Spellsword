using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicSwordAttack : Attack
    {
        public BasicSwordAttack(Character attacker, IWeapon basicSword)
        {
            this.User = attacker;
            this.Damage = basicSword.Damage + User.Strength;
            this.AttackElement = basicSword.ThisElement;
            this.Description = "Deals " + Damage + " damage to target.";
        }
    }
}

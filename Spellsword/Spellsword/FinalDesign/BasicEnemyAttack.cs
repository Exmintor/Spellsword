using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicEnemyAttack : Attack
    {
        public BasicEnemyAttack(Character attacker, Element element, int damage)
        {
            this.User = attacker;
            this.Damage = damage + User.Strength;
            this.AttackElement = element;
            this.Description = "Deals " + Damage + " " + AttackElement + " damage to target.";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicLightningSpell : Attack
    {
        private int initialDamage;
        public BasicLightningSpell(Character attacker, int damage)
        {
            initialDamage = damage;
            this.AttackElement = Element.Lightning;
            this.Name = "Lightning";
            this.User = attacker;
            this.Damage = initialDamage + User.Magic;
            this.Description = "Deals " + Damage + " " + this.AttackElement + "\ndamage to target";
        }

        public override void UpdateDescription()
        {
            this.Description = "Deals " + Damage + " " + this.AttackElement + "\ndamage to target";
            Damage = initialDamage + User.Magic;
            this.AttackElement = Element.Lightning;
        }
    }
}

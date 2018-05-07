﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicFireball : Attack
    {
        private int initialDamage;
        public BasicFireball(Character attacker, int damage)
        {
            initialDamage = damage;
            this.AttackElement = Element.Fire;
            this.Name = "Fireball";
            this.User = attacker;
            this.Damage = initialDamage + User.Magic;
            this.Description = "Deals " + Damage + " " + this.AttackElement + " damage to \ntarget";
        }

        public override void UpdateDescription()
        {
            this.Description = "Deals " + Damage + " " + this.AttackElement + " damage \nto target";
            Damage = initialDamage + User.Magic;
            this.AttackElement = Element.Fire;
        }
    }
}

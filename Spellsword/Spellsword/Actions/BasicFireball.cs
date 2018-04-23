﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicFireball : Attack
    {
        public BasicFireball(Character attacker)
        {
            this.Name = "Fireball";
            this.User = attacker;
            this.Damage = 15 + User.Magic;
            this.Description = "Deals " + Damage + " damage to \ntarget";
        }

        public override void UpdateDescription()
        {
            base.UpdateDescription();
            Damage = 15 + User.Magic;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class StrengthTalent : Talent
    {
        public override string Name { get; protected set; }
        public override int Cost { get; protected set; }
        public override string Description { get; protected set; }

        public StrengthTalent()
        {
            Name = "Increase Strength";
            Description = "Increases your current \nStrength by 1";
            Cost = 1;
        }
        public override void ApplyTalent(Character player)
        {
            player.IncreaseStrength(1);
        }
    }
}

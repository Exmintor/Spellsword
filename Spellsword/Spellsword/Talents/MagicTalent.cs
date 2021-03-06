﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class MagicTalent : Talent
    {
        public override string Name { get; protected set; }
        public override string Description { get; protected set; }
        public override int Cost { get; protected set; }

        public MagicTalent()
        {
            Name = "Increase Magic";
            Description = "Increases your current \nMagic by 5";
            Cost = 1;
        }
        public override void ApplyTalent(Character player)
        {
            base.ApplyTalent(player);
            player.IncreaseMagic(5);
        }
    }
}

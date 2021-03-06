﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicFocus : Weapon
    {
        public BasicFocus(string worldImage) : base(worldImage)
        {
            IsFocus = true;
            Damage = 4;
            Defense = 2;
            Name = "Spell Focus";

            string isFocus = "";
            if(IsFocus)
            {
                isFocus = "Can cast spells";
            }
            else
            {
                isFocus = "";
            }
            Description = Name +
                "\n    Attack: " + Damage +
                "\n    Defense: " + Defense +
                "\n    " + isFocus;
        }
    }
}

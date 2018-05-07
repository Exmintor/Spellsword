using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicShield : Weapon
    {
        public BasicShield(string worldImage) : base(worldImage)
        {
            Damage = 1;
            Defense = 8;
            Name = "Shield";

            string isFocus = "";
            if (IsFocus)
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

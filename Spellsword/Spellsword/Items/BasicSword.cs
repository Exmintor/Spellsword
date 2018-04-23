using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicSword : Weapon
    {
        public BasicSword()
        {
            this.IsSword = true;
            Damage = 10;
            Defense = 10;
            Name = "Sword";

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

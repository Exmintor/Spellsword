using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class IceShield : Weapon
    {
        public IceShield(string worldImage, int damage, int defense) : base(worldImage)
        {
            this.IsShield = true;
            Damage = damage;
            Defense = defense;
            ThisElement = Element.Ice;
            Name = "Ice Shield";

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
                "\n    Fire and Lightning \n    resistance." +
                "\n    " + isFocus;
        }
    }
}

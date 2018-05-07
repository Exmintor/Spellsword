using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicSword : Weapon
    {
        public BasicSword(string worldImage, int damage, int defense) : base(worldImage)
        {
            this.IsSword = true;
            Damage = damage;
            Defense = defense;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class IceSword : Weapon
    {
        public IceSword(string worldImage, int damage, int defense) : base(worldImage)
        {
            this.IsSword = true;
            Damage = damage;
            Defense = defense;
            ThisElement = Element.Ice;
            Name = "Ice Sword";

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
                "\n    Ice Damage" +
                "\n    " + isFocus;
        }
    }
}

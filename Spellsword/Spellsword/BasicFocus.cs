using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BasicFocus : Weapon
    {
        public BasicFocus()
        {
            IsFocus = true;
            Damage = 4;
            Defense = 4;
            Name = "Spell Focus";
        }
    }
}

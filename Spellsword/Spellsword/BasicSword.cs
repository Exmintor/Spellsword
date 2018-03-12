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
        }
    }
}

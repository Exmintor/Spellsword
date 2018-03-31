using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Weapon : Item,  IWeapon
    {
        public bool IsSword { get; protected set; }
        public bool IsShield { get; protected set; }
        public bool IsFocus { get; protected set; }

        public int Damage { get; protected set; }
        public int Defense { get; protected set; }

        public string Name { get; protected set; }

        public Weapon()
        {
            IsSword = false;
            IsShield = false;
            IsFocus = false;
            Damage = 0;
            Defense = 0;
            Name = "Basic Weapon";
        }
    }
}

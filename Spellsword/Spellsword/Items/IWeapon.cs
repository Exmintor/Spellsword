using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public interface IWeapon
    {
        bool IsSword { get; }
        bool IsShield { get; }
        bool IsFocus { get; }

        int Damage { get; }
        int Defense { get; }
        Element ThisElement { get; }

        string Name { get; }
        string Description { get; }
    }
}

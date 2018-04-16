using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Attack : IAction
    {
        public string Name { get; protected set; }
        public Character User { get; protected set; }
        public int Damage { get; protected set; }
    }
}

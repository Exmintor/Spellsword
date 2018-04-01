using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Attack : IAction
    {
        public Entity User { get; protected set; }
        public int Damage { get; protected set; }
    }
}

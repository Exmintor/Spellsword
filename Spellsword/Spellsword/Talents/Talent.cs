using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Talent
    {
        public abstract string Name { get; protected set; }
        public abstract int Cost { get; protected set; }
        public abstract void ApplyTalent(Entity player);
    }
}

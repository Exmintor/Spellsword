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
        public abstract string Description { get; protected set; }
        public abstract int Cost { get; protected set; }
        public virtual void ApplyTalent(Character player)
        {
            player.IncreaseHealth(10);
            player.IncreaseDefense(3);
        }
    }
}

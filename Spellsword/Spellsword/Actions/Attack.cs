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
        public string Description { get; protected set; }
        public Character User { get; protected set; }
        public int Damage { get; protected set; }
        public Element AttackElement { get; protected set; }

        public virtual void UpdateDescription()
        {
            this.Description = "Deals " + Damage + " damage to \ntarget";
        }
    }
}

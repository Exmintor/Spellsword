using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Entity
    {
        public int Health { get; protected set; }
        public virtual void TakeDamage(int damage)
        {
            this.Health -= damage;
        }

        public abstract IAction ChooseAction();
    }
}

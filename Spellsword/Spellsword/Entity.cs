using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public abstract class Entity
    {
        public event Action Died;

        public int Health { get; protected set; }
        public virtual void TakeDamage(int damage)
        {
            this.Health -= damage;
            if(this.Health <= 0)
            {
                if(Died != null)
                {
                    Died.Invoke();
                }
            }
        }

        public abstract IAction ChooseAction();
    }
}

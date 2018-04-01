using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Poison : IAction, IStatusEffect
    {
        public int Duration { get; private set; }

        public int Priority { get; private set; }

        public string Name { get; private set; }

        private int damagePerTurn;

        public Poison(int duration, int damagePerTurn)
        {
            this.Name = "Poison";
            this.Duration = duration;
            this.damagePerTurn = damagePerTurn;

            this.Priority = 2;
        }

        public void Resolve(Entity thisEntity)
        {
            thisEntity.TakeDamage(damagePerTurn);
            Duration--;
        }

        public void UnResolve(Entity thisEntity)
        {
            //Do nothing
        }
    }
}

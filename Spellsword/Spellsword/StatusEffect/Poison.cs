using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class Poison : IAction, IStatusEffect
    {
        public Entity User { get; protected set; }
        public int Duration { get; private set; }

        public int Priority { get; private set; }

        public string Name { get; private set; }

        private int damagePerTurn;

        public Poison(Entity attacker, int duration, int damagePerTurn)
        {
            this.User = attacker;
            this.Name = "Poison";
            this.Duration = duration;
            this.damagePerTurn = damagePerTurn + User.Magic;

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

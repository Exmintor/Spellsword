using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class BattleAction
    {
        private Entity attacker;
        private Entity target;
        private IAction action;

        public BattleAction(Entity attacker, Entity target, IAction action)
        {
            this.attacker = attacker;
            this.target = target;
            this.action = action;
        }

        public void Resolve()
        {
            if(action is Attack)
            {
                int damage = ((Attack)action).Damage;
                target.TakeDamage(damage);
            }
            if(action is Poison)
            {
                target.AddStatusEffect((Poison)action);
            }
        }
    }
}
